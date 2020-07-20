using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class UserOrderController : Controller
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly IProductRepository _productRepository;

        public UserOrderController(IShoppingCartItemRepository shoppingCartItemRepository, IProductRepository productRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Checkout(string Id)
        {
            List<ShoppingCartItemModel> Items = _shoppingCartItemRepository.GetItemsByCartId(Id);
            double full_price = 0;

            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Product = _productRepository.GetProduct(Items[i].ItemId);
                full_price += (Items[i].Ammount * Items[i].Product.Price);
            }

            CheckoutViewModel model = new CheckoutViewModel();

            model.FullPrice = full_price;
            model.OrderItems = Items;

            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel viewModel)
        {

            return View();
        }
    }
}
