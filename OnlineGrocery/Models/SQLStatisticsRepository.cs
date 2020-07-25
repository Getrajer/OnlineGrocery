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

        /// <summary>
        /// Will update latest register user
        /// </summary>
        public string ChangeLatestRegisterUser(string name, DateTime timeRegistred)
        {
            if (CheckIfStatExists())
            {

                //Get statistic
                Statistics up_stat = new Statistics();
                var old_stat = _context.Statistics.Find(1);
                up_stat = old_stat;

                //Update Info
                up_stat.LatestRegisterName = name;
                up_stat.LatestRegisterDate = timeRegistred;

                _context.Statistics.Update(up_stat);
                _context.SaveChanges();
                return name;
            }

            return name;
        }

        /// <summary>
        /// Will get latest user name and return it
        /// </summary>
        /// <returns>User Name / User Date</returns>
        public string GetLatestUserInfo()
        {
            Statistics stat = _context.Statistics.Find(1);
            string info = "";
            info = $"{stat.LatestRegisterName}|{stat.LatestRegisterDate.Day}.{stat.LatestRegisterDate.Month}.{stat.LatestRegisterDate.Year}";
            return info;
        }

        /// <summary>
        /// Will update number of users
        /// </summary>
        /// <param name="AddDelete">If true will add 1 / If false will substract 1</param>
        /// <returns></returns>
        public int UpdateUserAmmount(bool AddDelete)
        {
            if (AddDelete)
            {
                //Get statistic
                Statistics up_stat = new Statistics();
                var old_stat = _context.Statistics.Find(1);
                up_stat = old_stat;
                up_stat.AmmountOfUsers++;
                _context.Statistics.Update(up_stat);
                _context.SaveChanges();

                return up_stat.AmmountOfUsers; 
            }
            else
            {
                //Get statistic
                Statistics up_stat = new Statistics();
                var old_stat = _context.Statistics.Find(1);
                up_stat = old_stat;
                up_stat.AmmountOfUsers--;
                _context.Statistics.Update(up_stat);
                _context.SaveChanges();

                return up_stat.AmmountOfUsers;
            }
        }

        public int GetUserAmmount()
        {
            var stat = _context.Statistics.Find(1);
            return stat.AmmountOfUsers;
        }

        /// <summary>
        /// Will get mean per order
        /// </summary>
        public double GetOrderMean()
        {
            Statistics stat = _context.Statistics.Find(1);
            return stat.OrderMoneyMean;
        }

        /// <summary>
        /// Will update mean money spent per user order
        /// </summary>
        public double UpdateUserOrderMean(double moneyIn)
        {
            //Get statistic
            Statistics up_stat = new Statistics();
            var old_stat = _context.Statistics.Find(1);
            up_stat = old_stat;

            //Calc mean and update
            up_stat.OrderMoneyMean = (up_stat.OrderMoneyMean + moneyIn) / 2;
            _context.Statistics.Update(up_stat);
            _context.SaveChanges();
            return moneyIn;
        }

        public int GetTotalNumberOfOrders()
        {
            var stat = _context.Statistics.Find(1);
            return stat.TotalNumberOfOrders;
        }

        public int UpdateTotalNumberOfOrders()
        {
            //Get statistic
            Statistics up_stat = new Statistics();
            var old_stat = _context.Statistics.Find(1);
            up_stat = old_stat;

            up_stat.TotalNumberOfOrders++;
            _context.Statistics.Update(up_stat);
            _context.SaveChanges();
            return up_stat.TotalNumberOfOrders; ;
        }

        /// <summary>
        /// Will return full ammount of money to spend
        /// </summary>
        public double GetTotalSalesMoney()
        {
            var stat = _context.Statistics.Find(1);
            return stat.TotalSalesMoney;
        }

        public double UpdateTotalSalesMoney(double moneyIn)
        {
            //Get statistic
            Statistics up_stat = new Statistics();
            var old_stat = _context.Statistics.Find(1);
            up_stat = old_stat;
            up_stat.TotalSalesMoney += moneyIn;
            _context.Statistics.Update(up_stat);
            _context.SaveChanges();
            return moneyIn;
        }




        /// <summary>
        /// If there is no registration about statistics create one
        /// </summary>
        /// <returns></returns>
        public bool CheckIfStatExists()
        {
            int n = _context.Statistics.Count();

            if(n == 0)
            {
                Statistics stat = new Statistics();
                _context.Statistics.Add(stat);
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
