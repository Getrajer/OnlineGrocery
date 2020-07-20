using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IShoppingCartItemRepository
    {
        List<ShoppingCartItemModel> GetItemsByCartId(string Id);
    }
}
