using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IUserOrderRepository
    {
        UserOrderModel GetOrder(int Id);
        List<UserOrderModel> GetAllOrders();
        UserOrderModel AddOrder(UserOrderModel model);
        UserOrderModel GetNewest();
    }
}
