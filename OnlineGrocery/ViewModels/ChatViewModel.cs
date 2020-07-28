using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class ChatViewModel
    {
        public ChatViewModel()
        {
            ChatMessages = new List<ChatMessageModel>();
        }

        public string UserId { get; set; }
        public List<ChatMessageModel> ChatMessages { get; set; }

        [Required]
        public string MessageText { get; set; }
    }
}
