using System.Security.Claims;
using System.Threading.Tasks;
using Identity.Base.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Admin.Areas.Profile.Controllers
{
    [Area("Profile"), Authorize]
    [Route("Profile/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly DbContext _context;

        public HomeController(DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string id)
        {
            var user = await _context.Set<UserInfo>().Include(c => c.Images).FirstOrDefaultAsync(c => c.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)); 
            if (!string.IsNullOrEmpty(id))
            {
               user = await _context.Set<UserInfo>().Include(c => c.Images).FirstOrDefaultAsync(c => c.Id == id);
            }
            return View(user);
        }

        public IActionResult Timeline(string id)
        {
            return View(id);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _context.Set<UserInfo>().Include(c => c.Images).FirstOrDefaultAsync(c => c.Id == id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                return View("Index");
            }
            return View(model);
        }
    }
}