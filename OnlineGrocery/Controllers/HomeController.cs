﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICMSIndexRepository _cMSIndexRepository;

        public HomeController( ICMSIndexRepository cMSIndexRepository)
        {
            _cMSIndexRepository = cMSIndexRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();

            model.PageData = _cMSIndexRepository.Get(1);

            return View(model);
        }

        [AllowAnonymous]
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
