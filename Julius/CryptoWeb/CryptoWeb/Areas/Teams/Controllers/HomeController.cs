using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWeb.Areas.Teams.Controllers
{
    public class HomeController : Controller
    {
        [Area("Teams")]
        [Route("Teams/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
