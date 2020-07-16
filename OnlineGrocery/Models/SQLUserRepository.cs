using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;


        }

        public UserModel Add(UserModel userModel)
        {
            context.Users.Add(userModel);
            context.SaveChanges();
            return userModel;
        }

        public UserModel Delete(int Id)
        {
            UserModel user = context.Users.Find(Id);

            if(user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }

            return user;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return context.Users;
        }

        public UserModel GetUser(int Id)
        {
            return context.Users.Find(Id);
        }




        public UserModel Update(UserModel edit_user)
        {
            var user = context.Users.Attach(edit_user);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return edit_user;
        }
    }
}
