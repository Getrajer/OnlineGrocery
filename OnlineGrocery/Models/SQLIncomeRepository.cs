using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLIncomeRepository : IIncomeRepository
    {
        private readonly AppDbContext _context;

        public SQLIncomeRepository(AppDbContext context)
        {
            _context = context;
        }

        public ShopIncome AddIncome(ShopIncome income)
        {
            _context.Income.Add(income);
            _context.SaveChanges();
            return income;
        }

        public List<ShopIncome> GetAllIncomes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Function will return income form "Today"
        /// </summary>
        /// <returns></returns>
        public double GetDailyIncome()
        {
            List<ShopIncome> TotalIncome = _context.Income.ToList();
            TotalIncome.RemoveAll(o => o.Date.Date != DateTime.Now.Date);
            double dailyIncome = 0;
            for(int i = 0; i < TotalIncome.Count; i++)
            {
                dailyIncome += TotalIncome[i].MoneyIn;
            }
            return dailyIncome;
        }

        public List<ShopIncome> GetIncomesByTime(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }


    }
}
