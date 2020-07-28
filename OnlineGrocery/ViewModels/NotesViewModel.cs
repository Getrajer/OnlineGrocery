using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class NotesViewModel
    {
        public NotesViewModel()
        {
            Notes = new List<NoteModel>();
        }

        /// <summary>
        /// Notes to display
        /// </summary>
        public List<NoteModel> Notes { get; set; }


        //Data to create new note
        public string UserId { get; set; }
        public string CreatorsName { get; set; }
        [Required]
        public string NoteTitle { get; set; }
        [Required]
        public string NoteText { get; set; }
    }
}
