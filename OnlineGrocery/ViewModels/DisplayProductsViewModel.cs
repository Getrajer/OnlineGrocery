using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class DisplayProductsViewModel
    {
        /// <summary>
        /// This value determines which types of products are needed to be displayed
        /// </summary>
        public int CurrentType { get; set; }

        /// <summary>
        /// It controlls number of items to display
        /// </summary>
        public int ItemCount { get; set; }

        /// <summary>
        /// If to show button which allows user to load next 15 items
        /// </summary>
        public bool ShowNext { get; set; }

        /// <summary>
        /// If to show button which allows to load previous 15 items
        /// </summary>
        public bool ShowPrevious { get; set; }

        public List<ProductModel> Products = new List<ProductModel>();
    }
}
