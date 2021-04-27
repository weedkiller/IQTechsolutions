using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Messaging.Core.Context.Services;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.ViewComponents
{
    [ViewComponent(Name = "ActiveChats")]
    public class ActiveChats : ViewComponent
    {
        private readonly ChatContext _chatService;

        public ActiveChats(ChatContext chatService)
        {
            _chatService = chatService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chats = (await _chatService.GetChatUsersAsync())
                .Where(c => c.UserId == userId)
                .Select(c => c.Chat)
                .OrderByDescending(c => c.Modified)
                .ToList();
            return View(chats);
        }
    }
}
