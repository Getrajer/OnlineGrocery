using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IUserOrderItemRepository _userOrderItemRepository;
        private readonly IUserOrderRepository _userOrderRepository;

        public AdminController(IShoppingCartItemRepository shoppingCartItemRepository,
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


        public IActionResult MainAdminPage()
        {
            AdminMainPanelViewModel model = new AdminMainPanelViewModel();

            //Get Latest Order
            model.NewOrder = _userOrderRepository.GetNewest();

            //Get Daily Income 
            model.DayIncome = _incomeRepository.GetDailyIncome();

            //Daily ammount of new users
            model.NumberDayUsers = _userManager.Users.Where(o => o.TimeRegistred.Date == DateTime.Now.Date).Count();
            List<UserModel> users = _userManager.Users.ToList();
            model.NewUser = users[users.Count - 1];

            //Check stock
            model.NumberProductsLowOnStock = _productRepository.LowStockProductsNumber();
            model.StockIsFine = model.NumberProductsLowOnStock == 0 ? true : false;

            return View(model);
        }
    }
}
