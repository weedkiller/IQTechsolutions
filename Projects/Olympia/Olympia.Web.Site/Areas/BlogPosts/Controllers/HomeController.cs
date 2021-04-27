using Microsoft.AspNetCore.Mvc;

namespace Olympia.Web.Site.Areas.BlogPosts.Controllers
{
    [Area("Blog")]
    [Route("Blog/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
