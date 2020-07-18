using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderController(ISupplierRepository supplierRepository, IProductRepository productRepository, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult MakeOrder(int Id)
        {
            SuppliersModel s = _supplierRepository.GetSupplier(Id);
            List<OrderItemModel> OrderItems = new List<OrderItemModel>();

            List<ProductModel> Products = _productRepository.GetProductsOfSupplier(s.Name);

            for (int i = 0; i < Products.Count; i++)
            {
                OrderItemModel order = new OrderItemModel();
                order.Ammount = 10;
                order.ProductName = Products[i].Name;
                order.ProductId = Products[i].Id;
                OrderItems.Add(order);
            }


            CreateOrderViewModel viewModel = new CreateOrderViewModel();
            viewModel.OrderItems = OrderItems;
            viewModel.SupplierName = s.Name;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MakeOrder(CreateOrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                OrderModel order = new OrderModel();

                //When Created Id is +1 so in order of asigning it to the order item it needs to be decleared here
                int orderId = _orderRepository.OrdersCount();
                orderId++;

                //Add right order items to the database
                for (int i = 0; i < viewModel.OrderItems.Count; i++)
                {
                    viewModel.OrderItems[i].OrderId = orderId;
                    order.FullItemsAmmount += viewModel.OrderItems[i].Ammount;
                    _orderItemRepository.Add(viewModel.OrderItems[i]);
                }

                order.OrderDate = DateTime.Now;
                order.SupplierName = viewModel.SupplierName;
                _orderRepository.AddOrder(order);

                return RedirectToAction("DisplayOrders");
            }
            return View();
        }


        public IActionResult DisplayOrders()
        {
            List<OrderModel> Orders = _orderRepository.ReturnOrders().ToList();
            return View(Orders);
        }
    }
}
