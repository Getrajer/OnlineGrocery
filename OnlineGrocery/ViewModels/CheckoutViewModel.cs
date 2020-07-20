using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class CheckoutViewModel
    {
        public double FullPrice { get; set; }
        public List<ShoppingCartItemModel> OrderItems { get; set; }

        public string CardNumber { get; set; }
        public string MonthExpired { get; set; }
        public string YearExpired { get; set; }
        public int SecurityCode { get; set; }
    }
}
