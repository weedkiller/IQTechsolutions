using Microsoft.AspNetCore.Mvc;

namespace Olympia.Web.Site.Areas.Support.Controllers
{
    [Area("Support")]
    [Route("Support/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
