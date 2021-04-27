using Microsoft.AspNetCore.Mvc;

namespace Olympia.Web.Site.Areas.Profile.Controllers
{
    public class HomeController : Controller
    {
        [Area("Profile")]
        [Route("Profile/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
