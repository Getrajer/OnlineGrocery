using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class ShoppingCartItemModel
    {
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public int Ammount { get; set; }
        public string ShoppingCartId { get; set; }

        public int ItemId { get; set; }
        public string UserId { get; set; }
    }
}
