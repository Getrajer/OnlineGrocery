using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLOrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _context;

        public SQLOrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public OrderItemModel Add(OrderItemModel model)
        {
            _context.OrderItems.Add(model);
            _context.SaveChanges();
            return model;
        }

        public IEnumerable<OrderItemModel> GetAllItems()
        {
            return _context.OrderItems;
        }

        public OrderItemModel GetItem(int Id)
        {
            return _context.OrderItems.Find(Id);
        }

        public List<OrderItemModel> GetOrderItemsByOrderId(int Id)
        {
            List<OrderItemModel> unsorted = _context.OrderItems.ToList();
            List<OrderItemModel> sorted = new List<OrderItemModel>();

            for(int i = 0; i < unsorted.Count; i++)
            {
                if(unsorted[i].OrderId == Id)
                {
                    sorted.Add(unsorted[i]);
                }
            }

            return sorted;
        }
    }
}
