using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLShoppingCartItemRepository : IShoppingCartItemRepository
    {
        private readonly AppDbContext _context;

        public SQLShoppingCartItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ShoppingCartItemModel> GetItemsByCartId(string Id)
        {
            List<ShoppingCartItemModel> Items = _context.ShoppingCartItems.ToList();
            Items.RemoveAll(o => o.ShoppingCartId != Id);
            return Items;
        }
    }
}
