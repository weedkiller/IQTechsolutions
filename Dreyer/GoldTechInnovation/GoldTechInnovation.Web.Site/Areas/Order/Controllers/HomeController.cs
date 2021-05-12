using Microsoft.AspNetCore.Mvc;

namespace GoldTechInnovation.Web.Site.Areas.Order.Controllers
{
    [Area("Order")]
    [Route("Order/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TrackOrder()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}
