using Microsoft.AspNetCore.Mvc;

namespace Olympia.Web.Site.Areas.Projects.Controllers
{
    [Area("Projects")]
    [Route("Projects/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
