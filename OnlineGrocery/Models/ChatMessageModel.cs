using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class ChatMessageModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string MessageText { get; set; }
        public DateTime Posted { get; set; }
        public string UserName { get; set; }
    }
}
