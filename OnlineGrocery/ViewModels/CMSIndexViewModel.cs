using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class CMSIndexViewModel
    {
        //Contact form
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public CMSIndexPageModel Page { get; set; }
    }
}
