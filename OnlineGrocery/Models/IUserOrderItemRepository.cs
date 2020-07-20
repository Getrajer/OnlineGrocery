﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IUserOrderItemRepository
    {
        UserOrderItemModel GetOrder(int Id);
        List<UserOrderItemModel> GetAlltems();
        List<UserOrderItemModel> GettIemsOfOrderId(int Id);
        UserOrderItemModel AddOrderItem(UserOrderItemModel model);
    }
}
