using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Olympia.Web.Site.Areas.Engage.Controllers
{
    public class HomeController : Controller
    {
        [Area("Engage")]
        [Route("Engage/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
