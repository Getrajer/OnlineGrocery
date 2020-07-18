using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class OrderDetailsViewModel
    {
        public OrderModel Order { get; set; }
        public List<OrderItemModel> Items { get; set; }
    }
}
