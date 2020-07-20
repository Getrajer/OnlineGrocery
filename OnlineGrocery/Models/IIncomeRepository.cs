using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IIncomeRepository
    {
        List<ShopIncome> GetAllIncomes();
        List<ShopIncome> GetIncomesByTime(DateTime from, DateTime to);
        ShopIncome AddIncome(ShopIncome income);
        double GetDailyIncome();
    }
}
