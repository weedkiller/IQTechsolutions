using Microsoft.AspNetCore.Mvc;

namespace GoldTechInnovation.Web.Site.Areas.Services.Controllers
{

    [Area("Services")]
    [Route("Services/[controller]/[action]")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
