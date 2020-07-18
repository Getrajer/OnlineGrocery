using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IOrderItemRepository
    {
        public OrderItemModel Add(OrderItemModel model);

        public IEnumerable<OrderItemModel> GetAllItems();

        public OrderItemModel GetItem(int Id);

        public List<OrderItemModel> GetOrderItemsByOrderId(int Id);
    }
}
