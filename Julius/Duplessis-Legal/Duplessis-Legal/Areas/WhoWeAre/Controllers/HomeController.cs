using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Duplessis_Legal.Areas.WhoWeAre.Controllers
{
    [Area("WhoWeAre")]
    [Route("WhoWeAre/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
