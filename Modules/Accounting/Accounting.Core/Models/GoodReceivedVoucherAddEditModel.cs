using InventoryManagement.Base.Entities;
using Products.Base.Entities;
using Suppliers.Base.Entities;

namespace Accounting.Core.Models
{
    public class GoodReceivedVoucherAddEditModel
    {
        /// <summary>
        /// Gets or sets the <see cref="Supplier"/> that is delivering the order
        /// </summary>
        public Supplier Supplier { get; set; }

        /// <summary>
        /// The quantity to add to the <see cref="GoodReceivedVoucherDetails"/> details
        /// </summary>
        public double QtyToAdd { get; set; }

        /// <summary>
        /// The selected product to add to the <see cref="GoodReceivedVoucherDetails"/> details
        /// </summary>
        public Product SelectProduct { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="GoodReceivedVoucher"/> to be added
        /// </summary>
        public GoodReceivedVoucher GoodReceivedVoucher { get; set; }
    }
}
