using Microsoft.AspNetCore.Mvc;

namespace Olympia.Web.Site.Areas.Services.Controllers
{
    public class HomeController : Controller
    {
        [Area("Services")]
        [Route("Services/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
