using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class CreateMessageViewModel
    {
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
