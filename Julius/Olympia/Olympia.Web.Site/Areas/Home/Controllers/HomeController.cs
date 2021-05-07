using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympia.Web.Site.Areas.Home.Controllers
{
    [Area("Home")]
    [Route("Home/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public string OpenPopup()
        {
            return "<h1> This Is Modeless Popup Window</h1>";
        }
    }
   
}
