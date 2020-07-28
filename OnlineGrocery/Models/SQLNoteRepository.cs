using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class SQLNoteRepository : INotesRepository
    {
        private readonly AppDbContext _context;

        public SQLNoteRepository(AppDbContext context)
        {
            _context = context;
        }

        public NoteModel CreateNote(NoteModel note)
        {
            _context.TeamNotes.Add(note);
            _context.SaveChanges();
            return note;
        }

        public NoteModel DeleteNote(int Id)
        {
            NoteModel note = _context.TeamNotes.Find(Id);
            _context.TeamNotes.Remove(note);
            _context.SaveChanges();
            return note;
        }

        public NoteModel EditNote(NoteModel note)
        {
            _context.TeamNotes.Update(note);
            _context.SaveChanges();
            return note;
        }

        public NoteModel GetNote(int Id)
        {
            return _context.TeamNotes.Find(Id);
        }

        public List<NoteModel> GetNotes()
        {
            return _context.TeamNotes.ToList();
        }
    }
}
