using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoWeb.Web.Site.Areas.Blog.Controllers
{

    [Area("Blog")]
    [Route("Blog/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Details()
        //{
        //    return View();
        //}
    }
}
