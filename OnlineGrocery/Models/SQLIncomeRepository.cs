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

        public List<ShopIncome> GetIncomesByTime(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
