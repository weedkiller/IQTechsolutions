using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Base.Entities;
using InventoryManagement.Core.Context.Configurations.Services;
using InventoryManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Base.Entities;
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
                model.Details = voucher.Details;
                model.Supplier = voucher.Supplier;
            }
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetGoodsReceivedVoucher(string voucherId, string supplierId, string date)
        {
            try
            {
                var goodsReceivedVoucher = await _goodReceivedVoucherContext.GetAsync(voucherId);
                if (goodsReceivedVoucher == null)
                {
                    goodsReceivedVoucher = new GoodReceivedVoucher()
                    {
                        Id = voucherId,
                        DateReceived = Convert.ToDateTime(date),
                        SupplierId = supplierId
                    };
                    await _goodReceivedVoucherContext.AddAsync(goodsReceivedVoucher);
                }

                return Json(new { id = goodsReceivedVoucher.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> ProcessGoodsReceivedVoucher(string voucherId, string supplierId, string date)
        {
            try
            {
                var goodsReceivedVoucher = await _goodReceivedVoucherContext.GetAsync(voucherId);
                if (goodsReceivedVoucher == null)
                {
                    goodsReceivedVoucher = new GoodReceivedVoucher()
                    {
                        Id = voucherId,
                        DateReceived = Convert.ToDateTime(date),
                        SupplierId = supplierId
                    };
                    await _goodReceivedVoucherContext.AddAsync(goodsReceivedVoucher);
                }
                
                return Json(new { id = goodsReceivedVoucher.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        /// <summary>
        /// Updates or adds the <see cref="GoodReceivedVoucherDetails"/>
        /// </summary>
        /// <param name="voucherId">The identity of the <see cref="GoodReceivedVoucher"/></param>
        /// <param name="productId">The identity of the <see cref="Product"/></param>
        /// <param name="qty">The quantity of the <see cref="Product"/> to be added</param>
        /// <param name="priceExcl">The price of the <see cref="Product"/> to be added</param>
        /// <returns>The product's details that was updated</returns>
        public async Task<IActionResult> AddUpdateGoodsReceivedVoucherProduct(string voucherId, string productId, double qty, string priceExcl)
        {
            if (productId != null)
            {
                var product = await _productContext.GetAsync(productId);

                var price = Convert.ToDouble(priceExcl.Replace(".", ","));

                var vat = Math.Round((price * (1 + (product.VatRate / 100))) - price, 2);
                var incl = price + vat;

                var goodReceivedVoucherDetail = new GoodReceivedVoucherDetails()
                {
                    Qty = qty.ToString("N"),
                    ProductId = product.Id,
                    PriceExcl = price,
                    PriceVat = vat,
                    PriceIncl = incl
                };

                await _goodReceivedVoucherContext.AddUpdateDetailAsync(voucherId, goodReceivedVoucherDetail);

                return Json(new
                {
                    qty = qty,
                    id = product.Id,
                    name = product.Name,
                    pack = product.PackageItems.Count,
                    excl = price,
                    vat = vat,
                    incl = incl
                });
            }

            return null;
        }

        /// <summary>
        /// Gets the <see cref="Product"/> details
        /// </summary>
        /// <param name="productId">The identity of the <see cref="Product"/> to be retreived</param>
        /// <returns>The retreived <see cref="Product"/></returns>
        public async Task<IActionResult> GetProduct(string productId)
        {
            var product = await _productContext.GetAsync(productId);

            return Json(new
            {
                id = product.Id,
                name = product.Name,
                pack = product.PackageItems.Count,
                excl = product.CostExcl,
                vat = product.CostVat,
                incl = product.CostIncl
            });
        }

        /// <summary>
        /// Removes a <see cref="GoodReceivedVoucherDetails"/>
        /// </summary>
        /// <param name="voucherId">The identity of the <see cref="GoodReceivedVoucher"/></param>
        /// <param name="productId">The identity of the <see cref="Product"/></param>
        /// <returns>The product's details that was updated</returns>
        [HttpPost]
        public async Task<IActionResult> RemoveGoodsReceivedVoucherProduct(string voucherId, string productId)
        {
            var detail = await _goodReceivedVoucherContext.RemoveDetailAsync(voucherId, productId);
            return Json(new {voucherId = voucherId, productId = productId, excl = detail.PriceExcl, vat = detail.PriceVat, incl = detail.PriceIncl });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveGoodsReceivedVoucher(string voucherId)
        {
            var voucher = await _goodReceivedVoucherContext.RemoveAsync(voucherId);
            return Json(true);
        }
    }
}
