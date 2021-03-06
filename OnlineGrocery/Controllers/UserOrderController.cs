﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IStatisticsRepository _statisticsRepository;

        public UserOrderController(IShoppingCartItemRepository shoppingCartItemRepository, 
                                    IProductRepository productRepository,
                                    IIncomeRepository incomeRepository,
                                    IUserOrderItemRepository userOrderItemRepository,
                                    IUserOrderRepository userOrderRepository,
                                    UserManager<UserModel> userManager,
                                    IStatisticsRepository statisticsRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _productRepository = productRepository;
            _incomeRepository = incomeRepository;
            _userOrderItemRepository = userOrderItemRepository;
            _userOrderRepository = userOrderRepository;
            _userManager = userManager;
            _statisticsRepository = statisticsRepository;
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
            model.CartId = Id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //Add income to the database
                ShopIncome income = new ShopIncome();
                income.MoneyIn = viewModel.FullPrice;
                income.Date = DateTime.Now;
                _incomeRepository.AddIncome(income);

                //Add all items to the database and update stock
                List<ShoppingCartItemModel> Items = _shoppingCartItemRepository.GetItemsByCartId(viewModel.CartId);
                for (int i = 0; i < Items.Count; i++)
                {
                    //Add ordered item
                    Items[i].Product = _productRepository.GetProduct(Items[i].ItemId);
                    UserOrderItemModel user_item = new UserOrderItemModel();
                    user_item.Ammount = Items[i].Ammount;
                    user_item.ProductName = Items[i].Product.Name;
                    user_item.ProductOrderId = Items[i].Product.Id;
                    user_item.OrderId = Items[i].ShoppingCartId;
                    _userOrderItemRepository.AddOrderItem(user_item);

                    //Update stock
                    ProductModel product = _productRepository.GetProduct(Items[i].ItemId);
                    product.Quantity -= user_item.Ammount;
                    _productRepository.Update(product);
                }

                //Get user
                var user = await _userManager.GetUserAsync(HttpContext.User);

                //Create order object
                UserOrderModel user_order = new UserOrderModel();
                user_order.DateOfOrder = DateTime.Now;
                user_order.OrderId = viewModel.CartId;
                user_order.AdditionalInformation = viewModel.AdditionalInformation;
                user_order.FullPrice = viewModel.FullPrice;

                //Add user information
                user_order.UserId = user.Id;
                user_order.UserCity = user.City;
                user_order.UserEmail = user.Email;
                user_order.UserName = $"{user.FirstName} {user.LastName}";
                user_order.UserPhoneNumber = user.PhoneNumber;
                user_order.UserPostCode = user.PostCode;
                user_order.UserStreetAdress = $"{user.StreetName} {user.StreetNumber}";
                user_order.UserCity = user.City;

                _userOrderRepository.AddOrder(user_order);

                //Update statistics
                _statisticsRepository.UpdateUserOrderMean(viewModel.FullPrice);
                _statisticsRepository.UpdateTotalSalesMoney(viewModel.FullPrice);
                _statisticsRepository.UpdateTotalNumberOfOrders();

                //Update ordering user iformations
                user.OrdersAmmount++;
                user.MoneySpent += viewModel.FullAmmount;
                await _userManager.UpdateAsync(user);

                //Clear cart
                return RedirectToAction("ClearCartPayment", "Cart");
            }
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult UserOrders()
        {
            List<UserOrderModel> Orders = _userOrderRepository.GetAllOrders();
            Orders.Reverse();
            return View(Orders);
        }

        public IActionResult UserOrderDetails(int Id)
        {
            UserOrderDetailsViewModel model = new UserOrderDetailsViewModel();

            model.UserOrder = _userOrderRepository.GetOrder(Id);
            model.OrderedItems = _userOrderItemRepository.GettIemsOfOrderId(model.UserOrder.OrderId);

            return View(model);
        }

        public IActionResult LoadFirstStat()
        {
            Statistics stat = new Statistics();
            stat.AmmountOfUsers = 0;
            stat.LatestRegisterDate = DateTime.Now;
            stat.LatestRegisterName = "";
            stat.OrderMoneyMean = 0;
            stat.TotalNumberOfOrders = 0;
            stat.TotalSalesMoney = 0;
            stat.UsersMeanMoneySpent = 0;

            _statisticsRepository.CheckIfStatExists(stat);

            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult LoadMockData()
        {
            MockSalesDataLoader loader = new MockSalesDataLoader();
            List<string> lines = loader.LoadMockData();

            for (int i = 0; i < lines.Count; i++)
            {
                string[] line = lines[i].Split(",");
                UserOrderModel model = new UserOrderModel();

                model.FullPrice = Convert.ToInt32(line[0]);
                model.DateOfOrder = Convert.ToDateTime(line[1]);

                //Update statistics
                _statisticsRepository.UpdateUserOrderMean(Convert.ToDouble(line[0]));
                _statisticsRepository.UpdateTotalSalesMoney(Convert.ToDouble(line[0]));
                _statisticsRepository.UpdateTotalNumberOfOrders();

                _userOrderRepository.AddOrder(model);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
