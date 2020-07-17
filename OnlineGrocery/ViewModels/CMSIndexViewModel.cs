using Microsoft.AspNetCore.Http;
using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class CMSIndexViewModel
    {
        public int Id { get; set; }
        //Contact form
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public CMSIndexPageModel Page { get; set; }
        public IFormFile Photo1 { get; set; }
        public IFormFile Photo2 { get; set; }
        public IFormFile Photo3 { get; set; }



    }
}
