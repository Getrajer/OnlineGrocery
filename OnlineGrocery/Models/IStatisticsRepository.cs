using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    interface IStatisticsRepository
    {
        /// <summary>
        /// Will get latest user name and return it
        /// </summary>
        /// <returns>User Name / User Date</returns>
        string GetLatestUserName();
        /// <summary>
        /// Will update latest register user
        /// </summary>
        string ChangeLatestRegisterUser(string name, DateTime timeRegistred);

        int GetUserAmmount();
        /// <summary>
        /// Will update number of users
        /// </summary>
        /// <param name="AddDelete">If true will add 1 / If false will substract 1</param>
        /// <returns></returns>
        int UpdateUserAmmount(bool AddDelete);

        /// <summary>
        /// Will update mean of user spending
        /// </summary>
        /// <returns></returns>
        double UpdateUsersMeanSpent(double moneyIn);
        double GetUserMeanSpent();

        /// <summary>
        /// Will return full ammount of money to spend
        /// </summary>
        double GetTotalSalesMoney();
        double UpdateTotalSalesMoney(double moneyIn);

        /// <summary>
        /// Will get mean per order
        /// </summary>
        double GetOrderMean();
        double UpdateOrderMean(double moneyIn);


        int GetTotalNumberOfOrders();
        int UpdateTotalNumberOfOrders();
    }
}
