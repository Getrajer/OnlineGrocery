using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public SQLOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public OrderModel AddOrder(OrderModel model)
        {
            _context.Orders.Add(model);
            _context.SaveChanges();
            return model;
        }

        public int OrdersCount()
        {
            return _context.Orders.Count();
        }

        public IEnumerable<OrderModel> ReturnOrders()
        {
            return _context.Orders;
        }
    }
}
