using System.Collections.Generic;
using InventoryManagement.Base.Entities;
using Products.Base.Entities;
using Suppliers.Base.Entities;

namespace InventoryManagement.Core.Models
{
    public class GoodReceivedVoucherAddEditModel
    {
        /// <summary>
        /// Gets or sets the <see cref="Supplier"/> that is delivering the order
        /// </summary>
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Gets or sets the collection of <see cref="Supplier"/> that is available for delivery
        /// </summary>
        public IEnumerable<Supplier> SupplierList { get; set; } = new List<Supplier>();

        /// <summary>
        /// The quantity to add to the <see cref="GoodReceivedVoucherDetails"/> details
        /// </summary>
        public double QtyToAdd { get; set; }

        /// <summary>
        /// The selected product to add to the <see cref="GoodReceivedVoucherDetails"/> details
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the collection of <see cref="Product"/> that is available for GRV
        /// </summary>
        public IEnumerable<Product> ProductList { get; set; } = new List<Product>();

        /// <summary>
        /// Gets or sets the <see cref="GoodReceivedVoucher"/> to be added
        /// </summary>
        public GoodReceivedVoucher GoodReceivedVoucher { get; set; }

        /// <summary>
        /// Gets or sets the collection of <see cref="GoodReceivedVoucherDetails"/> that belongs to GRV
        /// </summary>
        public IEnumerable<GoodReceivedVoucherDetails> Details { get; set; } = new List<GoodReceivedVoucherDetails>();
    }
}
