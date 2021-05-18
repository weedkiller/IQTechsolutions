using Microsoft.AspNetCore.Mvc;

namespace GoldTechInnovation.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
