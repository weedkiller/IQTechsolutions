using Microsoft.AspNetCore.Mvc;

namespace GoldTechInnovation.Web.Site.Areas.Gallery.Controllers
{

    [Area("Gallery")]
    [Route("Gallery/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
