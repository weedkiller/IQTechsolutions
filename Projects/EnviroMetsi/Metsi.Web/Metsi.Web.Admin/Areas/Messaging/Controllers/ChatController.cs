using System.Security.Claims;
using System.Threading.Tasks;
using Filing.Base.Enums;
using Messaging.Base.Entities;
using Metsi.Web.Admin.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Site.Admin.Areas.Chats.Controllers
{
    [Authorize]
    [Area("Messaging")]
    [Route("Messaging/[controller]/[action]")]
    public class ChatController : Controller
    {
        private readonly IHubContext<ChatHub> _chat;

        public ChatController(IHubContext<ChatHub> chat)
        {
            _chat = chat;
        }

        [HttpPost("{connectionId}/{roomName}")]
        public async Task<IActionResult> JoinChat( string connectionId, string roomName)
        {
            await _chat.Groups.AddToGroupAsync(connectionId, roomName);
            return Ok();
        }

        [HttpPost("{connectionId}/{roomName}")]
        public async Task<IActionResult> LeaveChat(string connectionId, string roomName)
        {
            await _chat.Groups.RemoveFromGroupAsync(connectionId, roomName);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string messageInput, string chatId, string roomName)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var newMessage = new Message()
            //{
            //    MessageString = messageInput,
            //    ChatId = chatId,
            //    SenderId = user.Id,
            //    Name = $"{user.FirstName} {user.LastName}"
            //};

            //await chatService.AddMessageAsync(newMessage);

            ////await _chat.Clients.All.SendAsync("ReceiveMessage", user, messageInput);
            //await _chat.Clients.Group(roomName).SendAsync("ReceiveMessage", 
            //    user.Id, messageInput, 
            //    user.GetImage().GetImagePath(ImageType.Cover, "https://www.feawthings.com/img/av1.png", "http://www.feawthings.com"),
            //    newMessage.Created.ToShortTimeString(), $"{user.FirstName} {user.LastName}");

            return Ok();
        }
    }
}
