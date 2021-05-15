using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWeb.Areas.Shop.Controllers
{
    public class HomeController : Controller
    {
        [Area("Shop")]
        [Route("Shop/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
