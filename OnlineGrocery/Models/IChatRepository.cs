using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IChatRepository
    {
        ChatMessageModel CreateMessage(ChatMessageModel message);
        ChatMessageModel DeleteMessage(int Id);
        ChatMessageModel EditMessage(ChatMessageModel message);
        List<ChatMessageModel> GetMessages();
        ChatMessageModel GetMessage(int Id);
    }
}
