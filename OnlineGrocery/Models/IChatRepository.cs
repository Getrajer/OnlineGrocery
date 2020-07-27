using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IChatRepository
    {
        ChatMessageModel CreateMessage();
        ChatMessageModel DeleteMessage(int Id);
        ChatMessageModel EditMessage(int Id);
        ChatMessageModel GetMessages();
        ChatMessageModel GetMessage(int Id);
    }
}
