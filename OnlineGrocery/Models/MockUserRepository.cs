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

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _users;
        }

        public UserModel GetUser(int Id)
        {
            return _users.FirstOrDefault(e => e.Id == Id);
        }


    }
}
