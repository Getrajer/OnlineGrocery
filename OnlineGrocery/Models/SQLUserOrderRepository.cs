using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLUserOrderRepository : IUserOrderRepository
    {
        public UserOrderModel AddOrder(UserOrderModel model)
        {
            throw new NotImplementedException();
        }

        public List<UserOrderModel> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public UserOrderModel GetOrder(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
