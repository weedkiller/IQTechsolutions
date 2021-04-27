using DuPlessisLegal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DuPlessisLegal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OurFirm()
        {
            return View();
        }

        public IActionResult OurPeople()
        {
            return View();
        }

        public IActionResult OurPeopleDetail()
        {
            return View();
        }

        public IActionResult OurPractices()
        {
            return View();
        }
        public IActionResult Lists()
        {
            return View();
        }

        public IActionResult NewsEvents()
        {
            return View();
        }

        public IActionResult NewsDetails()
        {
            return View();
        }

        public IActionResult Location()
        {
            return View();
        }

        public IActionResult ShortCodes()
        {
            return View();
        }
        public IActionResult Buttons()
        {
            return View();
        }
        public IActionResult Columns()
        {
            return View();
        }
        public IActionResult FancyBoxes()
        {
            return View();
        }
        public IActionResult IconBoxes()
        {
            return View();
        }
        public IActionResult PricingTables()
        {
            return View();
        }
        public IActionResult ProgressBars()
        {
            return View();
        }
        public IActionResult Quotes()
        {
            return View();
        }
        public IActionResult Tabs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
