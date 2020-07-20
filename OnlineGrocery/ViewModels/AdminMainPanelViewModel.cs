using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class AdminMainPanelViewModel
    {
        //Newest User
        public UserModel NewUser { get; set; }
        //Number of new users in day
        public int NumberDayUsers { get; set; }

        //Newest order
        public UserOrderModel NewOrder { get; set; }
        //Number of new orders in day
        public int NumberOrdersDay { get; set; }

        //Added later
        public string MessagePlaceHolder { get; set; }

        //Daily icome
        public double DayIncome { get; set; }


        //Stock
        public int NumberProductsLowOnStock { get; set; }
        //If stock is fine it will display diffrent window
        public bool StockIsFine { get; set; }

    }
}
