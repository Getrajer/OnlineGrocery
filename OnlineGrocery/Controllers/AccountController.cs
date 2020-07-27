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
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IStatisticsRepository _statisticsRepository;

        public AccountController(UserManager<UserModel> userManager,
                                SignInManager<UserModel> signInManager,
                                IStatisticsRepository statisticsRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _statisticsRepository = statisticsRepository;
        }

        public IActionResult UsersListAdmin()
        {
            List<UserModel> model = _userManager.Users.ToList();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost][HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Account with {email} alredy exists!");
            }
        }

        [HttpPost]
        [AllowAnonymous]
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

                    //Change latest user 
                    _statisticsRepository.ChangeLatestRegisterUser($"{user.FirstName} {user.LastName}", user.TimeRegistred);
                    _statisticsRepository.UpdateUserAmmount(true);

                    result = await _userManager.AddToRoleAsync(user, "User");

                    return RedirectToAction("Index", "Home");

                }

                foreach (var error in result.Errors)
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
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                   
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

            if (user != null)
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

                if (user != null)
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

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> LoadMockData()
        {
            MockUserDataLoader loader = new MockUserDataLoader();
            List<string> lines = loader.LoadMockData();

            var successful = new List<string>();
            var failed = new List<string>();

            for (int i = 0; i < lines.Count; i++)
            {
                string[] line = lines[i].Split(",");

                UserModel user = new UserModel();
                user.FirstName = line[1];
                user.LastName = line[2];
                user.Email = line[3];
                user.City = line[5];
                user.StreetName = line[6];
                user.StreetNumber = line[7];
                user.PostCode = line[8];
                user.OrdersAmmount = Convert.ToInt32(line[9]);
                user.MoneySpent = Convert.ToDouble(line[10]);
                user.TimeRegistred = Convert.ToDateTime(line[11]);
                user.UserName = user.Email;

                var result = await _userManager.CreateAsync(user, line[4]);

                if (result.Succeeded)
                {
                    successful.Add(user.FirstName);
                }
                else
                {
                    failed.Add(user.FirstName);
                }
            }

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserAccount(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id {Id} cannot be fond";
                return View("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("EditUserInfo");
            }

        }
    }
}
