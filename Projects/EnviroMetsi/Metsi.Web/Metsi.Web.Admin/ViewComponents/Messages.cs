using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Messaging.Base.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Admin.ViewComponents
{
    [ViewComponent(Name = "Messages")]
    public class Messages : ViewComponent
    {
        private readonly DbContext _context;

        public Messages(DbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string chatId)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var messages = new List<Message>();
            if (!string.IsNullOrEmpty(chatId))
            {
                messages = await _context.Set<Message>().Include(c => c.Sender).Where(c => c.ChatId == chatId).ToListAsync();
            }
            return View(messages);
        }
    }
}
