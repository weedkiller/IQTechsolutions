using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympia.Web.Site.Areas.Who_we_are.Controllers
{
    [Area("Who_we_are")]
    [Route("Who_we_are/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
