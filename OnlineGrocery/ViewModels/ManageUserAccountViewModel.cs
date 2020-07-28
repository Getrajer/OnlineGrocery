using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class ManageUserAccountViewModel
    {
        public UserModel User { get; set; }
        public string AccountType { get; set; }
        public string UserId { get; set; }
    }
}
