using Microsoft.AspNetCore.Mvc;

namespace Olympia.Web.Site.Areas.Customers.Controllers
{
    [Area("Customers")]
    [Route("Customers/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
