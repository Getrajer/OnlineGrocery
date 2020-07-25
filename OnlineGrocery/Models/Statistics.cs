using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    /// <summary>
    /// This class will hold information about shop updated on changes
    /// </summary>
    public class Statistics
    {
        public int Id { get; set; }

        /// <summary>
        /// To showcase latest registered user name
        /// </summary>
        public string LatestRegisterName { get; set; }
        public DateTime LatestRegisterDate { get; set; }
        /// <summary>
        /// Will hold average money spent per user
        /// </summary>
        public double UsersMeanMoneySpent { get; set; }

        public int AmmountOfUsers { get; set; }

        /// <summary>
        /// Will hold data about total sales
        /// </summary>
        public double TotalSalesMoney { get; set; }

        /// <summary>
        /// Will hold mean about average money spent per order
        /// </summary>
        public double OrderMoneyMean { get; set; }
        public int TotalNumberOfOrders { get; set; }

    }
}
