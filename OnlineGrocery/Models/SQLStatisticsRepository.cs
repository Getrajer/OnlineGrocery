using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLStatisticsRepository : IStatisticsRepository
    {
        private readonly AppDbContext _context;

        public SQLStatisticsRepository(AppDbContext context)
        {
            _context = context;
        }

        public string ChangeLatestRegisterUser(string name, DateTime timeRegistred)
        {
            throw new NotImplementedException();
        }

        public string GetLatestUserName()
        {
            throw new NotImplementedException();
        }

        public double GetOrderMean()
        {
            throw new NotImplementedException();
        }

        public int GetTotalNumberOfOrders()
        {
            throw new NotImplementedException();
        }

        public double GetTotalSalesMoney()
        {
            throw new NotImplementedException();
        }

        public int GetUserAmmount()
        {
            throw new NotImplementedException();
        }

        public double GetUserMeanSpent()
        {
            throw new NotImplementedException();
        }

        public double UpdateOrderMean(double moneyIn)
        {
            throw new NotImplementedException();
        }

        public int UpdateTotalNumberOfOrders()
        {
            throw new NotImplementedException();
        }

        public double UpdateTotalSalesMoney(double moneyIn)
        {
            throw new NotImplementedException();
        }

        public int UpdateUserAmmount(bool AddDelete)
        {
            throw new NotImplementedException();
        }

        public double UpdateUsersMeanSpent(double moneyIn)
        {
            throw new NotImplementedException();
        }
    }
}
