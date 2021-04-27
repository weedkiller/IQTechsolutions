using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Iqt.Messaging.Entities;
using Messaging.Base.Entities;
using Messaging.Core.Context.Services;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.Areas.Messaging.Controllers
{
    /// <summary>
    /// Controller that manages the standard chat actions
    /// </summary>
    [Area("Messaging")]
    [Route("Messaging/[controller]/[action]")]
    public class HomeController : Controller
    {
        private ChatContext _service;

        #region Constructor 

        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected chat service</param>
        public HomeController(ChatContext service)
        {
            _service = service;
        }

        #endregion

        /// <summary>
        /// Gets a specific chat view otherwise the first available chat
        /// </summary>
        /// <param name="id">The identity of the chat that needs to be fetched</param>
        /// <returns>The chat view with its model</returns>
        public async Task<IActionResult> Chat(string id)
        {
            return View();
        }

        /// <summary>
        /// Gets the main chat page
        /// </summary>
        /// <returns>The main chat page</returns>
        public IActionResult Groups()
        {
            var chat = _service.GetChats(ChatType.Room);

            return View(chat);
        }

        /// <summary>
        /// Gets the main chat page
        /// </summary>
        /// <returns>The main chat page</returns>
        public async Task<IActionResult> Contacts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View();
        }

        /// <summary>
        /// Gets the main chat page
        /// </summary>
        /// <returns>The main chat page</returns>
        public async Task<IActionResult> Friends(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return View();
        }

        /// <summary>
        /// Adds a new friend to the users friend list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddFriend(string id)
        {
            return RedirectToAction("Contacts");
        }

        /// <summary>
        /// Removes a friend from the users friendlist
        /// </summary>
        /// <param name="id">The identity of the friend that is being removed</param>
        /// <returns></returns>
        public async Task<IActionResult> RemoveFriend(string id)
        {
            return RedirectToAction("Contacts");
        }

        /// <summary>
        /// Gets the create chat view
        /// </summary>
        /// <returns>The create view and relevant model</returns>
        [HttpGet]
        public async Task<IActionResult> CreateChat()
        {
            var entity = new Chat()
            {
                Type = ChatType.Room
            };

            return PartialView("_CreateChat", entity);
        }

        /// <summary>
        /// Gets the create view and model
        /// </summary>
        /// <returns>The create view and relevant model</returns>
        [HttpGet]
        public async Task<IActionResult> CreatePrivateChat(string userId)
        {
            var chats = _service.GetChats(ChatType.Private);

            var list = from chat in chats
                from chatUser in chat.Users
                where chatUser.UserId == userId
                select chat;

            if (!list.Any())
            {
               // var user = await _userManager.Users.FirstOrDefaultAsync(c => c.Id == userId);

                var entity = new Chat()
                {
                  //  Name = $"{user.FirstName} {user.LastName}",
                  //  Description = user.MoodStatus,
                    Type = ChatType.Private
                };

                //  model.Id = Guid.NewGuid().ToString();
                entity.Users.Add(new ChatUser()
                {
                    UserRole = ChatRole.Admin,
                    UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
                });
                entity.Users.Add(new ChatUser()
                {
                    UserRole = ChatRole.Member,
                    UserId = userId
                });
                await _service.AddChatAsync(entity);
            }

            return RedirectToAction("Chat", "Home", new { id = userId });
        }

        /// <summary>
        /// Posts the create model to the server
        /// </summary>
        /// <param name="model">The model to be posted to the server</param>
        /// <returns>The relevant view and model</returns>
        [HttpPost]
        public async Task<IActionResult> CreateChat([FromForm] Chat model)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                //  model.Id = Guid.NewGuid().ToString();
                model.Users.Add(new ChatUser()
                {
                    UserRole = ChatRole.Admin,
                    UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
                });
                await _service.AddChatAsync(model);

                return RedirectToAction("Index");
            }
            return PartialView("_CreateChat", model);
        }

        /// <summary>
        /// Joins the user to and already existing chat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> JoinChat(string id)
        {
            var chatuser = new ChatUser()
            {
                ChatId = id,
                UserRole = ChatRole.Admin,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
            };

            await _service.AddChatUserAsync(chatuser);

            return RedirectToAction("Chat", "Home", new{area="Chats", id = id});
        }
    }
}
