using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Base.Entities;
using InventoryManagement.Core.Context.Configurations.Services;
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
        private GoodReceivedVoucherContext _goodReceivedVoucherContext;

        public GoodsReceivedController(SupplierContext supplierContext, ProductContext productContext, GoodReceivedVoucherContext goodReceivedVoucherContext)
        {
            _supplierContext = supplierContext;
            _productContext = productContext;
            _goodReceivedVoucherContext = goodReceivedVoucherContext;
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

        [HttpPost]
        public async Task<IActionResult> ProcessGoodsReceivedVoucher(string supplierId)
        {
            var goodsReceivedVoucher = new GoodReceivedVoucher()
            {
                Id = Guid.NewGuid().ToString(),
                DateReceived = DateTime.Now,
                SupplierId = supplierId
            };
            await _goodReceivedVoucherContext.AddAsync(goodsReceivedVoucher);
            return Json(new{id=goodsReceivedVoucher.Id});
        }

        [HttpPost]
        public async Task<IActionResult> ProcessGoodsReceivedVoucherDetail(string parentId, string productId, int qty)
        {
            try
            {
                var product = await _productContext.GetAsync(productId);

                var detail = new GoodReceivedVoucherDetails()
                {
                    Qty = qty.ToString(),
                    ProductId = productId,
                    PriceExcl = qty * product.PriceExcl,
                    PriceVat = qty * product.Vat,
                    PriceIncl = qty * product.PriceIncl,
                    GoodReceivedVoucherId = parentId
                };
                await _goodReceivedVoucherContext.AddDetailAsync(detail);

                product.QtyInStock = product.QtyInStock + qty;
                await _productContext.UpdateAsync(product);

                return Json(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async Task<IActionResult> AddGoodsReceivedProduct(string id, double qty)
        {
            var product = await _productContext.GetAsync(id);
            var result = new
            {
                qty = qty,
                id = product.Id,
                name = product.Name,
                pack = product.PackageItems.Count,
                excl = product.PriceExcl,
                vat = product.Vat,
                incl = product.PriceIncl
            };
            return Json(result);
        }
    }
}
