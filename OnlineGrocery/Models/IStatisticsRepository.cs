using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IStatisticsRepository
    {

        string GetLatestUserInfo();
        string ChangeLatestRegisterUser(string name, DateTime timeRegistred);
        int GetUserAmmount();
        int UpdateUserAmmount(bool AddDelete);

        double GetTotalSalesMoney();
        double UpdateTotalSalesMoney(double moneyIn);


        double GetOrderMean();
        double UpdateUserOrderMean(double moneyIn);


        int GetTotalNumberOfOrders();
        int UpdateTotalNumberOfOrders();


        bool CheckIfStatExists();
    }
}
