using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Orders.Controllers
{
    [Area("Orders")]
    [Route("Orders/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}