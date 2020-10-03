using System;
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
        private readonly IInboxRepository _inboxRepository;

        public HomeController(ICMSIndexRepository cMSIndexRepository,
                               IInboxRepository inboxRepository)
        {
            _cMSIndexRepository = cMSIndexRepository;
            _inboxRepository = inboxRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();

            model.PageData = _cMSIndexRepository.Get(1);

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ShopMessageModel message = new ShopMessageModel();
                message.Email = viewModel.Email;
                message.Message = viewModel.Message;
                message.Name = viewModel.Name;
                message.Topic = viewModel.Topic;
                message.Sent = DateTime.Now;
                message.UserId = "Annonymous";
                message.TypeName = "Annonymous";
                message.Checked = false;
                message.Resolved = false;


                _inboxRepository.AddMessage(message);

                return RedirectToAction("Index");
            }

            return View(viewModel);
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
