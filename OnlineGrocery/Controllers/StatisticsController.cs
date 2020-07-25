using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;

namespace OnlineGrocery.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IUserOrderRepository _userOrderRepository;

        public StatisticsController(IUserOrderRepository userOrderRepository)
        {
            _userOrderRepository = userOrderRepository;
        }

        public IActionResult SalesStatistics()
        {


            return View();
        }
    }
}
