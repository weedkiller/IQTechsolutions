using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQTechSolutions.Web.Admin.Areas.Suppliers.Controllers
{
    public class GoodReceivedVoucherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
