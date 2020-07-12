using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class HomeIndexViewModel
    {
        public UserModel User { get; set; }

        public string PageTitle { get; set; }
    }
}
