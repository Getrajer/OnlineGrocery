using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLChatRepository : IChatRepository
    {

        private readonly AppDbContext _context;

        public SQLChatRepository(AppDbContext context)
        {
            _context = context;
        }

        public ChatMessageModel CreateMessage(ChatMessageModel message)
        {
            _context.ChatMessages.Add(message);
            _context.SaveChanges();
            return message;
        }

        public ChatMessageModel DeleteMessage(int Id)
        {
            var message = _context.ChatMessages.Find(Id);
            _context.ChatMessages.Remove(message);
            return message;
        }

        public ChatMessageModel EditMessage(ChatMessageModel message)
        {
            _context.ChatMessages.Update(message);
            _context.SaveChanges();
            return message;
        }

        public ChatMessageModel GetMessage(int Id)
        {
            return _context.ChatMessages.Find(Id);
        }

        public List<ChatMessageModel> GetMessages()
        {
            return _context.ChatMessages.ToList();
        }
    }
}
