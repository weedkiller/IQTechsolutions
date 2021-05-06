using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Core.Context.Configurations.Services;
using InventoryManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Base.Entities;

namespace IQTechSolutions.Web.Admin.Areas.Purchases.Controllers
{
    [Area("Purchases")]
    [Route("Purchases/{controller=Home}/{action=Index}/{id?}")]
    public class HomeController : Controller
    {
        private GoodReceivedVoucherContext _context;

        public HomeController(GoodReceivedVoucherContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GoodsReceivedVoucher()
        {
            var model = new GoodReceivedVoucherAddEditModel
            {
                SupplierList = _context.GetAll().ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult GoodsReceivedVoucher(GoodReceivedVoucherAddEditModel model)
        {
            return View();
        }
    }
}
