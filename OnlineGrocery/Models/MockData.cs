using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class MockData
    {
        private IUserRepository _userRepository;

        public MockData(IUserRepository user)
        {
            _userRepository = user;
        }

        public int Name { get; set; }

        public void LoadMockData()
        {
            //Load Mock data from the file
            List<string> lines = new List<string>();
            //Load recepies objects
            string FilePath = Path.GetFullPath(@"wwwroot\Users_Mock_Data.csv");
            lines = File.ReadAllLines(FilePath).ToList();


            for (int i = 0; i < lines.Count; i++)
            {
                string[] line = lines[i].Split(",");

                UserModel user = new UserModel();
                user.FirstName = line[1];
                user.LastName = line[2];
                user.Email = line[3];
                user.Password = line[4];
                user.City = line[5];
                user.StreetName = line[6];
                user.StreetNumber = line[7];
                user.PostCode = line[8];
                user.OrdersAmmount = Convert.ToInt32(line[9]);
                user.MoneySpent = Convert.ToDouble(line[10]);

                _userRepository.Add(user);
            }
        }
    }
}
