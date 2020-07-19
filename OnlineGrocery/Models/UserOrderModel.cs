using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class UserOrderModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderedItemsId { get; set; }
        public double FullPrice { get; set; }
        public DateTime DateOfOrder { get; set; }

        //Data needs to be taken and saved in case user would change it 
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserStreetAdress { get; set; }
        public string UserPostCode { get; set; }
        public string UserCity { get; set; }

        public string AdditionalInformation { get; set; }
    }
}
