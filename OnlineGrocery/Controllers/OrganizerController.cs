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

            model.Notes = _notesRepository.GetNotes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Notes(NoteModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                NoteModel note = new NoteModel();
                note.UserId = user.Id;
                note.CreatorsName = $"{user.FirstName} {user.LastName}";
                note.DatePosted = DateTime.Now;
                note.NoteText = viewModel.NoteText;
                note.NoteTitle = viewModel.NoteTitle;

                NoteModel n = _notesRepository.CreateNote(note);

                return RedirectToAction("Notes");
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Chat()
        {
            ChatViewModel model = new ChatViewModel();
            model.ChatMessages = _chatRepository.GetMessages();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Chat(ChatViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                ChatMessageModel message = new ChatMessageModel();
                message.UserId = user.Id;
                message.UserName = $"{user.FirstName} {user.LastName}";
                message.MessageText = viewModel.MessageText;
                message.Posted = DateTime.Now;

                _chatRepository.CreateMessage(message);

                return RedirectToAction("Chat");
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult MessagesInbox()
        {
            return View();
        }
    }
}
