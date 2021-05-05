using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQTechSolutions.Web.Admin.Controllers
{
    public class GoodReceivedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
