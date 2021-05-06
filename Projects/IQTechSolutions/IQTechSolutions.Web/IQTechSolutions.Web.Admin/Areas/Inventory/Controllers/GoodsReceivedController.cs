using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Base.Entities;
using InventoryManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Core.Context.Services;
using Suppliers.Core.Context.Services;

namespace IQTechSolutions.Web.Admin.Areas.Inventory.Controllers
{

    [Area("Inventory")]
    [Route("Inventory/{controller=GoodsReceived}/{action=Index}")]
    public class GoodsReceivedController : Controller
    {
        private SupplierContext _supplierContext;
        private ProductContext _productContext;

        public GoodsReceivedController(SupplierContext supplierContext, ProductContext productContext)
        {
            _supplierContext = supplierContext;
            _productContext = productContext;
        }

        public async Task<IActionResult> Index()
        {
            var model = new GoodReceivedVoucherAddEditModel()
            {
                SupplierList = await _supplierContext.GetAll().Where(c => c.Active).ToListAsync(),
                ProductList = await _productContext.GetAll().Where(c => c.Active).ToListAsync(),
                GoodReceivedVoucher = new GoodReceivedVoucher()
            };
            return View(model);
        }
    }
}
