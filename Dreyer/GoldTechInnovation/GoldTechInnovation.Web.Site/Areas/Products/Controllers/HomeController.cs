using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldTechInnovation.Web.Site.Areas.Products.Controllers
{

    [Area("Products")]
    [Route("Products/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Testing for link between Controller and ProductList2 View
        public IActionResult ProductList2()
        {
            return View();
        }

        // Testing for link between Controller and ProductList3 View
        public IActionResult ProductList3()
        {
            return View();
        }

        // Testing for link between Controller and ProductDetails View
        public IActionResult Details()
        {
            return View();
        }
    }
}
