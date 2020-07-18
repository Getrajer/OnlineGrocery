using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IOrderRepository
    {
        OrderModel AddOrder(OrderModel model);

        IEnumerable<OrderModel> ReturnOrders();
    }
}
