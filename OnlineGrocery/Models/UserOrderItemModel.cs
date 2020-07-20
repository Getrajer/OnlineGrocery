using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class UserOrderItemModel
    {
        public int Id { get; set; }
        public int ProductOrderId { get; set; }
        public string ProductName { get; set; }
        public string OrderId { get; set; }
        public int Ammount { get; set; }
    }
}
