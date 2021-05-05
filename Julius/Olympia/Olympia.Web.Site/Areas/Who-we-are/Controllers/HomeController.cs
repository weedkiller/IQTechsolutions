using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Olympia.Web.Site.Areas.Who_we_are.Controllers
{
    public class HomeController : Controller
    {
        [Area("Who_we_are")]
        [Route("Who_we_are/[controller]/[action]")]


        public IActionResult Index()
        {
            return View();
        }
    }
}
