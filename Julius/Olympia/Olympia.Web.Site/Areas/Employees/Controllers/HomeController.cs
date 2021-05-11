using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympia.Web.Site.Areas.Employees.Controllers
{
    [Area("Employees")]
    [Route("Employees/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult UsaOffice()
        {
            return View(); 
        }
<<<<<<< Updated upstream
=======
        
        

>>>>>>> Stashed changes
    }
}
