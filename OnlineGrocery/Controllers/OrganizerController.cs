using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IInboxRepository _inboxRepository;

        public OrganizerController(UserManager<UserModel> userManager,
                                    IChatRepository chatRepository,
                                    INotesRepository notesRepository,
                                    RoleManager<IdentityRole> roleManager,
                                    IInboxRepository inboxRepository)
        {
            _userManager = userManager;
            _chatRepository = chatRepository;
            _notesRepository = notesRepository;
            _roleManager = roleManager;
            _inboxRepository = inboxRepository;
        }

        /// <summary>
        /// This function allows team members to leave notes for everyone
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Notes()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            NotesViewModel model = new NotesViewModel();

            model.Notes = _notesRepository.GetNotes();
            model.UserId = user.Id;

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
        public async Task<IActionResult> Chat()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ChatViewModel model = new ChatViewModel();
            model.ChatMessages = _chatRepository.GetMessages();
            model.UserId = user.Id;

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
            List<ShopMessageModel> Messages = _inboxRepository.GetMessages();
            return View(Messages);
        }

        [HttpGet]
        public IActionResult OpenMessage(int Id)
        {
            OpenMessageViewModel model = new OpenMessageViewModel();
            ShopMessageModel message = _inboxRepository.GetMessage(Id);
            model.Message = message;
            model.Id = model.Message.Id;
            model.IsResolved = message.Resolved;

            //Check message was open
            message.Checked = true;
            _inboxRepository.UpdateMessage(message);
            return View(model);
        }

        [HttpPost]
        public IActionResult OpenMessage(OpenMessageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ShopMessageModel message = _inboxRepository.GetMessage(viewModel.Id);

                if (viewModel.IsResolved == message.Resolved)
                {
                    return RedirectToAction("MessagesInbox");
                }
                else
                {
                    message.Resolved = viewModel.IsResolved;
                    _inboxRepository.UpdateMessage(message);
                    return RedirectToAction("MessagesInbox");
                }
            }

            return View(viewModel);
        }

        /// <summary>
        /// This is for user to send message
        /// </summary>
        [HttpGet]
        public IActionResult CreateMessageUser()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateMessageUser(CreateMessageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                ShopMessageModel message = new ShopMessageModel();
                message.Checked = false;
                message.Message = viewModel.Message;
                message.Resolved = false;
                message.Sent = DateTime.Now;
                message.Topic = viewModel.Topic;

                message.Email = user.Email;
                message.Name = $"{user.FirstName} {user.LastName}";
                message.UserId = user.Id;

                _inboxRepository.AddMessage(message);

                return RedirectToAction("UserPage", "Account");
            }

            return View(viewModel);
        }
    }
}
