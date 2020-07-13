using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class MockUserRepository : IUserRepository
    {
        private List<UserModel> _users;

        public MockUserRepository()
        {
            //Load Mock data from the file
            List<string> lines = new List<string>();
            //Load recepies objects
            string FilePath = Path.GetFullPath(@"wwwroot\Users_Mock_Data.csv");
            lines = File.ReadAllLines(FilePath).ToList();

            _users = new List<UserModel>();

            for (int i = 0; i < lines.Count; i++)
            {
                string[] line = lines[i].Split(",");

                UserModel user = new UserModel();
                user.Id = Convert.ToInt32(line[0]);
                user.FirstName = line[1];
                user.LastName = line[2];
                user.Email = line[3];
                user.Password = line[4];
                user.City = line[5];
                user.StreetName = line[6];
                user.StreetNumber = line[7];
                user.PostCode = line[8];

                _users.Add(user);
            }
        }

        public UserModel Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public UserModel Delete(int Id)
        {
            UserModel user = _users.FirstOrDefault(e => e.Id == Id);
            if(user != null)
            {
                _users.Remove(user);
            }

            return user;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _users;
        }

        public UserModel GetUser(int Id)
        {
            return _users.FirstOrDefault(e => e.Id == Id);
        }

        public UserModel Update(UserModel edit_user)
        {
            UserModel user = _users.FirstOrDefault(e => e.Id == edit_user.Id);
            if (user != null)
            {
                user.FirstName = edit_user.FirstName;
                user.LastName = edit_user.LastName;
                user.City = edit_user.City;
                user.Email = edit_user.Email;
                user.Password = edit_user.Password;
                user.PostCode = edit_user.PostCode;
                user.StreetName = edit_user.StreetName;
                user.StreetNumber = edit_user.StreetNumber;
            }

            return user;
        }
    }
}
