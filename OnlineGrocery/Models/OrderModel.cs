using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class OrderModel
    {
        //This Id is for database
        public int Id { get; set; }

        //This Id stores information about single order 
        public int OrderId { get; set; }

        public int SupplyierId { get; set; }
        public int ProductId { get; set; }
        public int Ammount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
