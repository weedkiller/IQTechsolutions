using System.Security.Claims;
using System.Threading.Tasks;
using Identity.Base.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Admin.ViewComponents
{
    public class MainMenuViewComponent : ViewComponent
    {
        private DbContext _context;

        public MainMenuViewComponent(DbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Set<UserInfo>().Include(c => c.Images).FirstOrDefaultAsync(c => c.Id == userId.ToString());

            return View(user);
        }
    }

}
