using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public UsersController(UserManager<UserModel> userManager, 
                                SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult UsersListAdmin()
        {
            List<UserModel> model = _userManager.Users.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel();
                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;
                user.Email = viewModel.Email;
                user.UserName = viewModel.Email;
                user.City = viewModel.City;
                user.StreetName = viewModel.StreetName;
                user.StreetNumber = viewModel.StreetNumber;
                user.PostCode = viewModel.PostCode;
                user.PhoneNumber = viewModel.PhoneNumber;
                user.MoneySpent = 0;
                user.OrdersAmmount = 0;
                user.TimeRegistred = DateTime.Now;
                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }

            return View(viewModel);
        }

        /// <summary>
        /// Will dsiplay user details for logged in user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> UserPage()
        {
            UserPageViewModel model = new UserPageViewModel();

            var user = await _userManager.GetUserAsync(HttpContext.User);

            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.City = user.City;
            model.StreetName = user.StreetName;
            model.StreetNumber = user.StreetNumber;
            model.PostCode = user.PostCode;
            model.PhoneNumber = user.PhoneNumber;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUserInfo()
        {
            EditUserInfoViewModel model = new EditUserInfoViewModel();
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if(user != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Email = user.Email;
                model.City = user.City;
                model.StreetName = user.StreetName;
                model.StreetNumber = user.StreetNumber;
                model.PostCode = user.PostCode;
                model.PhoneNumber = user.PhoneNumber;
                model.Id = user.Id;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUserInfo(EditUserInfoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(viewModel.Id);

                if(user != null)
                {
                    user.City = viewModel.City;
                    user.Email = viewModel.Email;
                    user.FirstName = viewModel.FirstName;
                    user.LastName = viewModel.LastName;
                    user.PhoneNumber = viewModel.PhoneNumber;
                    user.PostCode = viewModel.PostCode;
                    user.StreetName = viewModel.StreetName;
                    user.StreetNumber = viewModel.StreetNumber;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserPage");
                    }

                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(viewModel);
        }
    }
}
