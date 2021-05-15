using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWeb.Areas.Prices.Componets
{
    public class HomeController : Controller
    {
        [Area("Prices")]
        [Route("Prices/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
