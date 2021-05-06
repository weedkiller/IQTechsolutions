using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Base.Entities;
using InventoryManagement.Core.Models;
using Microsoft.EntityFrameworkCore;

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

        #region Add Goods Received Voucher

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
        public async Task<GoodReceivedVoucher> AddAsync(GoodReceivedVoucherAddEditModel model)
        {

            //await model.Entity.Images.AddImages(model.ImagesUpload, new Size(600,400));
            await _context.Set<GoodReceivedVoucher>().AddAsync(model.GoodReceivedVoucher);


            await _context.SaveChangesAsync();
            return model.GoodReceivedVoucher;
        }

        #endregion
    }
}
