using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly UserManager<UserModel> _userManager;

        private readonly ShoppingCartModel _shoppingCart;
        public CartController(IProductRepository productRepository,
                              ShoppingCartModel shoppingCart,
                              UserManager<UserModel> userManager)
        {
            _shoppingCart = shoppingCart;
            _productRepository = productRepository;
            _userManager = userManager;
        }
        public IActionResult CartDisplay()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new CartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(sCVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddToShoppingCartDisplayProducts(DisplayProductsViewModel model)
        {
            var selectedProduct = _productRepository.GetProduct(model.Id);
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, model.Quantity, user.Id);
            }
            return RedirectToAction("DisplayProducts", "Product", new { id = 1 });
        }

        public IActionResult RemoveAllOfItem(int Id)
        {
            var selectedProduct = _productRepository.GetProduct(Id);

            if(selectedProduct != null)
            {
                _shoppingCart.RemoveAllOfItem(selectedProduct);
            }

            return RedirectToAction("CartDisplay", "Cart");
        }

        public IActionResult RemoveFromShoppingCart(int Id)
        {
            var selectedProduct = _productRepository.GetProduct(Id);

            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("CartDisplay", "Cart");
        }

        public IActionResult ClearChart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("CartDisplay", "Cart");
        }
    }
}
