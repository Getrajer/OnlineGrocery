using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLUserOrderItemRepository : IUserOrderItemRepository
    {
        public UserOrderItemModel AddOrderItem(UserOrderModel model)
        {
            throw new NotImplementedException();
        }

        public List<UserOrderItemModel> GetAlltems()
        {
            throw new NotImplementedException();
        }

        public UserOrderItemModel GetOrder(int Id)
        {
            throw new NotImplementedException();
        }

        public List<UserOrderItemModel> GettIemsOfOrderId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
