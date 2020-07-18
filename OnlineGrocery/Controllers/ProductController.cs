using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;

        public ProductController(IWebHostEnvironment hostingEnvironment, IProductRepository productRepository, ISupplierRepository supplierRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
        }

        /// <summary>
        /// This function shows products in Display products page. It sorts theb by category.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult DisplayProducts(int Id)
        {
            DisplayProductsViewModel model = new DisplayProductsViewModel();

            List<ProductModel> Products = (_productRepository.GetAllProducts()).ToList();

            model.CurrentType = Id;

            //If user sorts to diffrent categort reset item counter
            if(model.CurrentType != Id) { model.ItemCount = 0; }

            string type_choice = "";

            switch (Id)
            {
                case 1: type_choice = "All"; break;
                case 2: type_choice = "Vegetables"; break;
                case 3: type_choice = "Fruits"; break;
                case 4: type_choice = "Meats"; break;
                case 5: type_choice = "Fish"; break;
                case 6: type_choice = "Drinks"; break;
                case 7: type_choice = "Creams"; break;
                case 8: type_choice = "DatesNuts"; break;
                case 9: type_choice = "Bakeary"; break;
                case 10: type_choice = "Baby"; break;
                case 11: type_choice = "Other"; break;
            }

            //If to showcase all products there is no if() statement
            if(type_choice == "All")
            {
                for (int i = 0; i < 15; i++)
                {
                    model.Products.Add(Products[i]);
                    model.ItemCount++;

                    //If there is more than 15 items allow user to scroll for them
                    if (i + 1 == 15 && (i + 1 >= Products.Count)) { model.ShowNext = true; }

                    //If there is no more products
                    if (Products.Count == i + 1)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 15; i++)
                {
                    if (Products[i].Type == type_choice) { model.Products.Add(Products[i]); }
                    model.ItemCount++;

                    //If there is more than 15 items allow user to scroll for them
                    if (i + 1 == 15 && (i + 1 >= Products.Count)) { model.ShowNext = true; }

                    //If there is no more products
                    if (Products.Count == i + 1)
                    {
                        break;
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            ProductCreateViewModel model = new ProductCreateViewModel();
            model.Suppliers = (_supplierRepository.ReturnSuppliers()).ToList();
            return View(model);
        }

        /// <summary>
        /// Will create new product and add it to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateProduct(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                SuppliersModel s = _supplierRepository.GetSupplier(model.SupplierId);
                string ImgPath = ProcessUploadedFile(model);

                ProductModel product = new ProductModel();
                product.Description = model.Description;
                product.ImgPath = ImgPath;
                product.Name = model.Name;
                product.Price = model.Price;
                product.Quantity = model.Quantity;
                product.Type = model.Type;
                product.SupplierId = model.SupplierId;
                product.SupplierName = s.Name;

                _productRepository.Add(product);

                return RedirectToAction("ProductDetails", new { id = product.Id });
            }
            return View();
        }

        /// <summary>
        /// Will show details of the product
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductDetails(int? Id)
        {
            ProductModel product = _productRepository.GetProduct(Id.Value);

            if(product == null)
            {
                Response.StatusCode = 404;
                return View("ProductNotFound", Id.Value);
            }

            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel()
            {
                product = product,
                PageTitle = product.Name
            };

           

            return View(productDetailsViewModel);
        }

        /// <summary>
        /// This function will pass EditProductViewmodel to the edit window and it will display edit window
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditProduct(int Id)
        {
            EditProductViewModel model = new EditProductViewModel();
            ProductModel p = _productRepository.GetProduct(Id);


            model.Id = Id;
            model.Description = p.Description;
            model.Name = p.Name;
            model.Price = p.Price;
            model.Quantity = p.Quantity;
            model.Title = "Edit " + p.Name;
            model.PhotoPath = p.ImgPath;
            model.Type = p.Type;
            model.Photo = null;

            model.SupplierId = p.SupplierId;
            model.Suppliers = (_supplierRepository.ReturnSuppliers()).ToList();

            return View(model);
        }

        /// <summary>
        /// This function will post editing the file to the database
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditProduct(EditProductViewModel viewModel)
        {
            string ImgPath = "";

            if (ModelState.IsValid)
            {
                //If there was an old image and user is editing one then chage image
                if(viewModel.Photo != null)
                {
                    string filepath = Path.Combine(_hostingEnvironment.WebRootPath, "images", viewModel.PhotoPath);
                    System.IO.File.Delete(filepath);
                    ProductCreateViewModel pm = new ProductCreateViewModel();

                    ImgPath = ProcessEditFile(viewModel);
                }

                SuppliersModel s = _supplierRepository.GetSupplier(viewModel.SupplierId);

                //Create new file with edited variables
                ProductModel new_p = new ProductModel();
                new_p.Id = viewModel.Id;
                new_p.Description = viewModel.Description;
                new_p.Name = viewModel.Name;
                new_p.Price = viewModel.Price;
                new_p.Quantity = viewModel.Quantity;
                new_p.Type = viewModel.Type;
                new_p.SupplierId = viewModel.SupplierId;
                new_p.SupplierName = s.Name;

                if(ImgPath != "")
                {
                    new_p.ImgPath = ImgPath;
                }
                else
                {
                    new_p.ImgPath = viewModel.PhotoPath;
                }

                _productRepository.Update(new_p);
            }
            return RedirectToAction("ProductsListAdmin");
        }

        /// <summary>
        /// This function will delete product from the database and image from images folder
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult DeleteProduct(EditProductViewModel viewModel)
        {
            //Delete image
            if(viewModel.PhotoPath != null)
            {
                string filepath = Path.Combine(_hostingEnvironment.WebRootPath, "images", viewModel.PhotoPath);
                System.IO.File.Delete(filepath);
            }

            _productRepository.Delete(viewModel.Id);

            return RedirectToAction("ProductsListAdmin");
        }

        /// <summary>
        /// This function will show list of products for admin managment system
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductsListAdmin()
        {
            var model = _productRepository.GetAllProducts();

            return View(model);
        }


        #region Helping Functions
        /// <summary>
        /// This function will process image path
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string ProcessUploadedFile(ProductCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        /// <summary>
        /// This function will process image path
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string ProcessEditFile(EditProductViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        #endregion
    }
}

