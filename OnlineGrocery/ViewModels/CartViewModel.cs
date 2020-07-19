using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class CartViewModel
    {
        public ShoppingCartModel ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
