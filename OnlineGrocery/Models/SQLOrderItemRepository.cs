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
    }
}
