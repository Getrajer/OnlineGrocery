using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class ProductController : Controller
    {

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

                

            }

            return View();
        }

        /// <summary>
        /// Will show details of the product
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductDetails(int? Id)
        {


            return View();
        }
    }
}
