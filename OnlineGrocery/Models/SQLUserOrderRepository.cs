using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLUserOrderRepository : IUserOrderRepository
    {
        private readonly AppDbContext _context;

        public SQLUserOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public UserOrderModel AddOrder(UserOrderModel model)
        {
            _context.UserOrders.Add(model);
            _context.SaveChanges();
            return model;
        }

        public List<UserOrderModel> GetAllOrders()
        {
            return _context.UserOrders.ToList();
        }

        public UserOrderModel GetNewest()
        {
            return _context.UserOrders.Find(_context.UserOrders.Count());
        }

        public UserOrderModel GetOrder(int Id)
        {
            return _context.UserOrders.Find(Id);
        }
    }
}
