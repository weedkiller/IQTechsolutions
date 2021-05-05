using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Base.Entities;
using InventoryManagement.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Core.Context.Services
{
    public class GoodReceivedVoucherService
    {
        #region Private Members

        private readonly DbContext _context;

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// The Default Constructor
        /// </summary>
        /// <param name="context">The injected database context</param>
        /// <param name="fileFactory">The injected file factory</param>
        public GoodReceivedVoucherService(DbContext context)
        {
            _context = (DbContext) context;
        }

        #endregion

        #region Add Product

        public IQueryable<GoodReceivedVoucher> GetAll()
        {
            var bb = _context.Set<GoodReceivedVoucher>().Include(c => c.Details).Include(c => c.Supplier);
            return bb;
        }

        public async Task<GoodReceivedVoucher> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds a specific product
        /// </summary>
        /// <param name="model">The model to be added from</param>
        /// <returns>The product that was added</returns>
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
