using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympia.Web.Site.Areas.Engaging.Controllers
{
    public class EngagingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
