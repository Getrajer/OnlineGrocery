using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUserRepository _userRepository;

        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                
            };

            var model = _productRepository.GetAllProducts();

            return View(model);
        }

        public JsonResult Details(int id)
        {
            UserModel model = _userRepository.GetUser(id);
            return Json(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
