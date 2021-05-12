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

        public async Task<IActionResult> Create(string id)
        {
            var model = new GoodReceivedVoucherAddEditModel()
            {
                SupplierList = await _supplierContext.GetAll().Where(c => c.Active).ToListAsync(),
                ProductList = await _productContext.GetAll().Where(c => c.Active).ToListAsync(),
                GoodReceivedVoucher = new GoodReceivedVoucher()
                {
                    Id = Guid.NewGuid().ToString()
                }
            };

            if (!string.IsNullOrEmpty(id))
            {
                var voucher = await _goodReceivedVoucherContext.GetAsync(id);
                model.GoodReceivedVoucher = voucher;
                model.Supplier = voucher.Supplier;
            }
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessGoodsReceivedVoucher(string supplierId, string date)
        {
            try
            {
                var goodsReceivedVoucher = new GoodReceivedVoucher()
                {
                    Id = Guid.NewGuid().ToString(),
                    DateReceived = Convert.ToDateTime(date),
                    SupplierId = supplierId
                };
                await _goodReceivedVoucherContext.AddAsync(goodsReceivedVoucher);
                return Json(new { id = goodsReceivedVoucher.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> ProcessGoodsReceivedVoucherDetail(string parentId, string productId, int qty, double? priceExcl)
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

                if (priceExcl != null)
                {
                    product.CostExcl = priceExcl.Value;
                }
                
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

        public async Task<IActionResult> AddGoodsReceivedProduct(string id, double qty, double priceExcl)
        {
            var product = await _productContext.GetAsync(id);
            var result = new
            {
                qty = qty,
                id = product.Id,
                name = product.Name,
                pack = product.PackageItems.Count,
                excl = product.CostExcl,
                vat = product.CostVat,
                incl = product.CostIncl
            };
            return Json(result);
        }
    }
}
