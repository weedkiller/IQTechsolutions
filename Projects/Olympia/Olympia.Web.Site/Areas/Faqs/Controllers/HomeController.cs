using Microsoft.AspNetCore.Mvc;

namespace Olympia.Web.Site.Areas.Faqs.Controllers
{
    [Area("Faqs")]
    [Route("Faqs/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
