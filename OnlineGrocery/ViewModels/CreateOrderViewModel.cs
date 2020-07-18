using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class CreateOrderViewModel
    {
        public string SupplierName { get; set; }
        public int SupplierId { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
}
}
