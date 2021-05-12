using Microsoft.AspNetCore.Mvc;

namespace GoldTechInnovation.Web.Site.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
