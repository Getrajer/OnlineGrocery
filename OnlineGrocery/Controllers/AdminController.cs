using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IUserOrderItemRepository _userOrderItemRepository;
        private readonly IUserOrderRepository _userOrderRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IShoppingCartItemRepository shoppingCartItemRepository,
                                    IProductRepository productRepository,
                                    IIncomeRepository incomeRepository,
                                    IUserOrderItemRepository userOrderItemRepository,
                                    IUserOrderRepository userOrderRepository,
                                    UserManager<UserModel> userManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _productRepository = productRepository;
            _incomeRepository = incomeRepository;
            _userOrderItemRepository = userOrderItemRepository;
            _userOrderRepository = userOrderRepository;
            _userManager = userManager;
            _roleManager = roleManager;
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

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = model.RoleName;

                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ManageRoles", "Admin");
                }

                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ManageRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with {Id} cannot be fount";
                return View("NotFound");
            }

            EditRoleViewModel model = new EditRoleViewModel();
            model.RoleName = role.Name;
            model.Id = role.Id;

            foreach(var user in await _userManager.Users.ToListAsync())
            {
                if(await _userManager.IsInRoleAsync(user, role.Name)) 
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel viewModel) 
        {
            var role = await _roleManager.FindByIdAsync(viewModel.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with {viewModel.Id} cannot be fount";
                return View("NotFound");
            }
            else
            {
                role.Name = viewModel.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ManageRoles");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(viewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string RoleId)
        {
            ViewBag.roleId = RoleId;

            var role = await _roleManager.FindByIdAsync(RoleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with {RoleId} cannot be fount";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach(var user in await _userManager.Users.ToListAsync())
            {
                UserRoleViewModel roleModel = new UserRoleViewModel();
                roleModel.UserId = user.Id;
                roleModel.UserName = user.UserName;


                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    roleModel.IsSelected = true;
                }
                else
                {
                    roleModel.IsSelected = false;
                }

                model.Add(roleModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> users_roles, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with {roleId} cannot be fount";
                return View("NotFound");
            }

            for(int i = 0; i < users_roles.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(users_roles[i].UserId);

                IdentityResult result = null;

                if (users_roles[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if(!users_roles[i].IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (users_roles.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return View();
        }


        public async Task<IActionResult> DeleteRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with {Id} cannot be fount";
                return View("NotFound");
            }
            else
            {
                var result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ManageRoles");
                }
                
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ManageRoles");
            }
        }


        [HttpGet]
        public IActionResult CreateEmployeeAccount()
        {
            CreateEmployeeAccountViewModel model = new CreateEmployeeAccountViewModel();

            model.Roles = _roleManager.Roles.ToList();

            return View(model);
        }


        [HttpPost]
        public IActionResult CreateEmployeeAccount(CreateEmployeeAccountViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                UserModel user = new UserModel();
            }
        }

    }
}
