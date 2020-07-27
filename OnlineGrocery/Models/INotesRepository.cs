using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface INotesRepository
    {
        NoteModel CreateNote();
        NoteModel EditNote(int Id);
        NoteModel DeleteNote(int Id);
    }
}
