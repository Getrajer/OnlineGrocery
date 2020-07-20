using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLUserOrderItemRepository : IUserOrderItemRepository
    {
        private readonly AppDbContext _context;

        public SQLUserOrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public UserOrderItemModel AddOrderItem(UserOrderItemModel model)
        {
            _context.UserOrdersItems.Add(model);
            _context.SaveChanges();
            return model;
        }

        public List<UserOrderItemModel> GetAlltems()
        {
            return _context.UserOrdersItems.ToList();
        }

        public UserOrderItemModel GetOrder(int Id)
        {
            return _context.UserOrdersItems.Find(Id);
        }

        public List<UserOrderItemModel> GettIemsOfOrderId(string Id)
        {
            List<UserOrderItemModel> Items = _context.UserOrdersItems.ToList();
            Items.RemoveAll(o => o.OrderId != Id);
            return Items;
        }
    }
}
