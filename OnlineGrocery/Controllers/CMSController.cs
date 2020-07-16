using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineGrocery.Controllers
{
    public class CMSController : Controller
    {
        public IActionResult CMSIndexPage()
        {
            return View();
        }
    }
}
