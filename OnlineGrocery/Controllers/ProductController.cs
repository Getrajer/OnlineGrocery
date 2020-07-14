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


    }
}

