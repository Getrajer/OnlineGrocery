using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class MockSalesDataLoader
    {
        public List<string> LoadMockData()
        {
            //Load Mock data from the file
            List<string> lines = new List<string>();
            //Load recepies objects
            string FilePath = Path.GetFullPath(@"wwwroot\SalesMockData.csv");
            lines = File.ReadAllLines(FilePath).ToList();

            return lines;
        }
    }
}
