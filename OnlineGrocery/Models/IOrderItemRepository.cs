using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IOrderItemRepository
    {
        public OrderItemModel Add(OrderItemModel model);

        public OrderItemModel GetAllItems();

        public OrderItemModel GetItem();
    }
}
