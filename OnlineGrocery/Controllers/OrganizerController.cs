using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineGrocery.Controllers
{
    public class OrganizerController : Controller
    {

        /// <summary>
        /// This function allows team members to leave notes for everyone
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Notes()
        {
            return View();
        }


    }
}
