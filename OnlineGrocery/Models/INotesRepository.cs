using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public interface INotesRepository
    {
        NoteModel CreateNote(NoteModel note);
        NoteModel EditNote(NoteModel note);
        NoteModel DeleteNote(int Id);
        List<NoteModel> GetNotes();
        NoteModel GetNote(int Id);
    }
}
