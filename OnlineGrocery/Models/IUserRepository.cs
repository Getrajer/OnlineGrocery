using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface IUserRepository
    {
        UserModel GetUser(int Id);

        IEnumerable<UserModel> GetAllUsers();
    }
}
