using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class OrganizerController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IChatRepository _chatRepository;
        private readonly INotesRepository _notesRepository;

        public OrganizerController(UserManager<UserModel> userManager,
                                    IChatRepository chatRepository,
                                    INotesRepository notesRepository)
        {
            _userManager = userManager;
            _chatRepository = chatRepository;
            _notesRepository = notesRepository;
        }

        /// <summary>
        /// This function allows team members to leave notes for everyone
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Notes()
        {
            NotesViewModel model = new NotesViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Notes(NoteModel noteModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                NoteModel note = new NoteModel();
                note.UserId = user.Id;
                note.CreatorsName = $"{user.FirstName} {user.LastName}";
                note.DatePosted = DateTime.Now;
                note.NoteText = note.NoteText;
                note.NoteTitle = note.NoteTitle;

                NoteModel n = _notesRepository.CreateNote(note);
            }
        }

        [HttpGet]
        public IActionResult Chat()
        {
            ChatViewModel model = new ChatViewModel();
            return View(model);
        }


        [HttpGet]
        public IActionResult MessagesInbox()
        {
            return View();
        }
    }
}
