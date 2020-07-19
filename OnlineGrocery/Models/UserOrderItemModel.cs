using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class UserOrderItemModel
    {
        public int Id { get; set; }
        public int ItemOrderId { get; set; }
        public string ItemName { get; set; }
        public int Ammount { get; set; }
    }
}
