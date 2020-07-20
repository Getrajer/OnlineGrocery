using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class UserOrderController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IUserOrderItemRepository _userOrderItemRepository;
        private readonly IUserOrderRepository _userOrderRepository;

        public UserOrderController(IShoppingCartItemRepository shoppingCartItemRepository, 
                                    IProductRepository productRepository,
                                    IIncomeRepository incomeRepository,
                                    IUserOrderItemRepository userOrderItemRepository,
                                    IUserOrderRepository userOrderRepository,
                                    UserManager<UserModel> userManager)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _productRepository = productRepository;
            _incomeRepository = incomeRepository;
            _userOrderItemRepository = userOrderItemRepository;
            _userOrderRepository = userOrderRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Checkout(string Id)
        {
            List<ShoppingCartItemModel> Items = _shoppingCartItemRepository.GetItemsByCartId(Id);
            CheckoutViewModel model = new CheckoutViewModel();

            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Product = _productRepository.GetProduct(Items[i].ItemId);
                model.FullPrice += (Items[i].Ammount * Items[i].Product.Price);
                model.FullAmmount += Items[i].Ammount;
            }
            model.OrderItems = Items;

            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

            }


            return View();
        }
    }
}
