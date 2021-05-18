using System;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Base.Entities;
using InventoryManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Products.Base.Entities;

namespace InventoryManagement.Core.Context.Configurations.Services
{
    /// <summary>
    /// The context of the Goods Received Voucher
    /// </summary>
    public class GoodReceivedVoucherContext
    {
        #region Private Members

        private readonly DbContext _context;

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// The Default Constructor
        /// </summary>
        /// <param name="context">The injected <see cref="GoodReceivedVoucher"/></param>
        public GoodReceivedVoucherContext(DbContext context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Gets all the Goods Received Vouchers in the database
        /// </summary>
        /// <returns></returns>
        public IQueryable<GoodReceivedVoucher> GetAll()
        {
            var bb = _context.Set<GoodReceivedVoucher>().Include(c => c.Details).Include(c => c.Supplier);
            return bb;
        }

        /// <summary>
        /// Gets a specific <see cref="GoodReceivedVoucher"/>
        /// </summary>
        /// <param name="id">The identity of the voucher</param>
        /// <returns>The specific <see cref="GoodReceivedVoucher"/></returns>
        public async Task<GoodReceivedVoucher> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds a specific <see cref="GoodReceivedVoucher"/>
        /// </summary>
        /// <param name="model">The model to be added from</param>
        /// <returns>The <see cref="GoodReceivedVoucher"/> that was added</returns>
        public async Task<GoodReceivedVoucher> AddAsync(GoodReceivedVoucher model)
        {

            //await model.Entity.Images.AddImages(model.ImagesUpload, new Size(600,400));
            await _context.Set<GoodReceivedVoucher>().AddAsync(model);


            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<GoodReceivedVoucher> RemoveAsync(string id)
        {
            var voucher = await GetAsync(id);
            foreach (var detail in voucher.Details)
            {
                _context.Set<GoodReceivedVoucherDetails>().Remove(detail);
            }
            _context.Set<GoodReceivedVoucher>().Remove(voucher);
            await _context.SaveChangesAsync();
            return voucher;
        }

        #region Goods Received Voucher Details

        public async Task<GoodReceivedVoucherDetails> GetDetailAsync(string voucherId, string productId)
        {
            var detail = await _context.Set<GoodReceivedVoucherDetails>().Where(c => c.GoodReceivedVoucherId == voucherId).FirstOrDefaultAsync(c => c.ProductId == productId);

            return detail;
        }

        /// <summary>
        /// Adds or updates the <see cref="GoodReceivedVoucherDetails"/>
        /// </summary>
        /// <param name="voucherId">The <see cref="GoodReceivedVoucherDetails"/> identity</param>
        /// <param name="model">The <see cref="GoodReceivedVoucherDetails"/> to be added or updated</param>
        /// <returns></returns>
        public async Task<GoodReceivedVoucherDetails> AddUpdateDetailAsync(string voucherId, GoodReceivedVoucherDetails model)
        {
            var detail = await GetDetailAsync(voucherId, model.ProductId);

            if (detail == null)
            {
                model.GoodReceivedVoucherId = voucherId;
                await _context.Set<GoodReceivedVoucherDetails>().AddAsync(model);
            }
            else
            {
                detail.Qty = detail.Qty + model.Qty;
                _context.Set<GoodReceivedVoucherDetails>().Update(detail);
            }
            
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<GoodReceivedVoucherDetails> RemoveDetailAsync(string voucherId, string productId)
        {
            var detail = await GetDetailAsync(voucherId, productId);
            var qty = detail.Qty;

            if (qty > 1)
            {
                detail.Qty = qty - 1;
                _context.Set<GoodReceivedVoucherDetails>().Update(detail);
            }
            else
            {
                _context.Set<GoodReceivedVoucherDetails>().Remove(detail);
            }

            await _context.SaveChangesAsync();

            return detail;
        }

        #endregion
    }
}
