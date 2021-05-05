using System.Linq;
using System.Threading.Tasks;
using Accounting.Base.Entities;
using InventoryManagement.Base.Entities;
using InventoryManagement.Core.Context.Services;
using InventoryManagement.Core.Models;

namespace InventoryManagement.Core.Context.Configurations.Services
{
    /// <summary>
    /// The context of the Goods Received Voucher
    /// </summary>
    public class GoodReceivedVoucherContext
    {
        #region Private Members

        private readonly GoodReceivedVoucherService _service;

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// The Default Constructor
        /// </summary>
        /// <param name="service">The injected <see cref="GoodReceivedVoucher"/></param>
        public GoodReceivedVoucherContext(GoodReceivedVoucherService service)
        {
            _service = service;
        }

        #endregion

        #region Add Goods Received Voucher

        /// <summary>
        /// Gets all the Goods Received Vouchers in the database
        /// </summary>
        /// <returns></returns>
        public IQueryable<GoodReceivedVoucher> GetAll()
        {
            var bb = _service.GetAll();
            return bb;
        }

        /// <summary>
        /// Gets a specific <see cref="GoodReceivedVoucher"/>
        /// </summary>
        /// <param name="id">The identity of the voucher</param>
        /// <returns>The specific <see cref="GoodReceivedVoucher"/></returns>
        public async Task<GoodReceivedVoucher> GetAsync(string id)
        {
            return await _service.GetAsync(id);
        }

        /// <summary>
        /// Adds a specific <see cref="GoodReceivedVoucher"/>
        /// </summary>
        /// <param name="model">The model to be added from</param>
        /// <returns>The <see cref="GoodReceivedVoucher"/> that was added</returns>
        public async Task<GoodReceivedVoucher> AddAsync(GoodReceivedVoucherAddEditModel model)
        {
            return await _service.AddAsync(model);
        }

        #endregion
    }
}
