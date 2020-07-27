using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteText { get; set; }
        public string CreatorsName { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
