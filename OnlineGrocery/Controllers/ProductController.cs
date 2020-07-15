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

        public ProductController(IWebHostEnvironment hostingEnvironment, IProductRepository productRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _productRepository = productRepository;
        }

        public IActionResult DisplayProducts()
        {
            var model = _productRepository.GetAllProducts();

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
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
                string ImgPath = ProcessUploadedFile(model);

                ProductModel product = new ProductModel();
                product.Description = model.Description;
                product.ImgPath = ImgPath;
                product.Name = model.Name;
                product.Price = model.Price;
                product.Quantity = model.Quantity;

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

            return View(model);
        }

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

                //Create new file with edited variables
                ProductModel new_p = new ProductModel();
                new_p.Id = viewModel.Id;
                new_p.Description = viewModel.Description;
                new_p.ImgPath = ImgPath;
                new_p.Name = viewModel.Name;
                new_p.Price = viewModel.Price;
                new_p.Quantity = viewModel.Quantity;
                new_p.Type = viewModel.Type;


                _productRepository.Update(new_p);
            }

            return RedirectToAction("DisplayProducts");
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

