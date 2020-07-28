using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IInboxRepository
    {
        ShopMessageModel AddMessage(ShopMessageModel model);
        ShopMessageModel GetMessage(int Id);
        List<ShopMessageModel> GetMessages();
        ShopMessageModel UpdateMessage(ShopMessageModel model);
        ShopMessageModel DeleteMessage(ShopMessageModel model);
    }
}
