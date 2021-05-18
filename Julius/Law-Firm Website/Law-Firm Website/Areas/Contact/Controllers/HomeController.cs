using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Law_Firm_Website.Areas.Contact.Controllers
{
    public class HomeController : Controller
    {
        [Area("Contact")]
        [Route("Contact/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
