using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLInboxRepository : IInboxRepository
    {
        private readonly AppDbContext _context;

        public SQLInboxRepository(AppDbContext context)
        {
            _context = context;
        }

        public ShopMessageModel AddMessage(ShopMessageModel model)
        {
            _context.MessagesInbox.Add(model);
            _context.SaveChanges();
            return model;
        }

        public ShopMessageModel DeleteMessage(ShopMessageModel model)
        {
            _context.MessagesInbox.Remove(model);
            _context.SaveChanges();
            return model;
        }

        public ShopMessageModel GetMessage(int Id)
        {
            return _context.MessagesInbox.Find(Id);
        }

        public List<ShopMessageModel> GetMessages()
        {
            return _context.MessagesInbox.ToList();
        }

        public ShopMessageModel UpdateMessage(ShopMessageModel model)
        {
            _context.MessagesInbox.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
