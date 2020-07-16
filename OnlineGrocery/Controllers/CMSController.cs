using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class CMSController : Controller
    {
        private ICMSIndexRepository _cMSIndexRepository;

        public CMSController(ICMSIndexRepository cMSIndexRepository)
        {
            _cMSIndexRepository = cMSIndexRepository;
        }

        public IActionResult CMSIndexPage()
        {
            CMSIndexViewModel model = new CMSIndexViewModel();
            model.Page = _cMSIndexRepository.Get(3);
            return View(model);
        }

        public void LoadData()
        {
            CMSIndexLoader i = new CMSIndexLoader();
            _cMSIndexRepository.Add(i.PageLoad());
        }
    }
}
