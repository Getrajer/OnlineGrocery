using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class OpenMessageViewModel
    {
        public ShopMessageModel Message { get; set; }

        public bool IsResolved { get; set; }
        public int Id { get; set; }
    }
}
