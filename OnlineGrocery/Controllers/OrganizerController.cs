using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;

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
            return View();
        }

        [HttpGet]
        public IActionResult Chat()
        {
            return View();
        }


        [HttpGet]
        public IActionResult MessagesInbox()
        {
            return View();
        }
    }
}
