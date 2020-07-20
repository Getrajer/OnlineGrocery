using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class UserOrderDetailsViewModel
    {
        public UserOrderModel UserOrder { get; set; }
        public List<UserOrderItemModel> OrderedItems { get; set; }
    }
}
