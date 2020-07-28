using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class ShopMessageModel
    {
        public int Id { get; set; }

        //If not annonymous
        public string UserId { get; set; }
        public string TypeName { get; set; }

        public string Topic { get; set; }
        public string Message { get; set; }
        public DateTime Sent { get; set; }

        public bool Checked { get; set; }
        //If this message is complaint or anything of that type it is either solved or not
        public bool Resolved { get; set; }
    }
}
