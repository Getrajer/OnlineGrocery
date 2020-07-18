using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class EmailSupplierOrderModel
    {
        public string Reciever { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
    }
}
