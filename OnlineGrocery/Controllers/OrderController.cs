using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;

namespace OnlineGrocery.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;

        public OrderController(ISupplierRepository supplierRepository, IProductRepository productRepository)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
        }

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
                OrderItems.Add(order);
            }

            return View(OrderItems);
        }
    }
}
