using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace OnlineGrocery.Controllers
{
    [Authorize(Roles = "Admin")]
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
                order.Ammount = 0;
                order.ProductName = Products[i].Name;
                order.ProductId = Products[i].Id;
                OrderItems.Add(order);
            }


            CreateOrderViewModel viewModel = new CreateOrderViewModel();
            viewModel.OrderItems = OrderItems;
            viewModel.SupplierName = s.Name;
            viewModel.SupplierId = Id;
            return View(viewModel);
        }

        [HttpPost]
        public async Task <IActionResult> MakeOrder(CreateOrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                OrderModel order = new OrderModel();
                string items_string_list = "";
                //When Created Id is +1 so in order of asigning it to the order item it needs to be decleared here
                int orderId = _orderRepository.OrdersCount();
                orderId++;

                //Add right order items to the database
                for (int i = 0; i < viewModel.OrderItems.Count; i++)
                {
                    viewModel.OrderItems[i].OrderId = orderId;
                    order.FullItemsAmmount += viewModel.OrderItems[i].Ammount;
                    _orderItemRepository.Add(viewModel.OrderItems[i]);
                    items_string_list += $"Product: {viewModel.OrderItems[i].ProductName} | Quantity: {viewModel.OrderItems[i].Ammount} \n";
                }

                order.OrderDate = DateTime.Now;
                order.SupplierName = viewModel.SupplierName;
                _orderRepository.AddOrder(order);

                SuppliersModel supplier = _supplierRepository.GetSupplier(viewModel.SupplierId);
                //Send email with order
                //await PostMail(supplier, order, items_string_list);

                return RedirectToAction("DisplayOrders");
            }
            return View();
        }

        /// <summary>
        /// This function will send email to supplier with list of items to order
        /// </summary>
        /// <param name="supplier"></param>
        /// <param name="order"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task PostMail(SuppliersModel supplier, OrderModel order, string items)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(supplier.Email);
            mm.Subject = $"New order from Online Groceary";
            mm.Body = "Here is the order: \n" + items;
            mm.IsBodyHtml = false;
            mm.From = new MailAddress("getrajer533@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("email", "password");
            await smtp.SendMailAsync(mm);
        }

        public IActionResult DisplayOrders()
        {
            List<OrderModel> Orders = _orderRepository.ReturnOrders().ToList();
            return View(Orders);
        }


        /// <summary>
        /// Will show details of the order
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult OrderDetails(int Id)
        {
            OrderModel order = _orderRepository.GetOrder(Id);
            List<OrderItemModel> orderItems = _orderItemRepository.GetOrderItemsByOrderId(Id);

            OrderDetailsViewModel viewModel = new OrderDetailsViewModel();
            viewModel.Items = orderItems;
            viewModel.Order = order;

            return View(viewModel);
        }
    }
}
