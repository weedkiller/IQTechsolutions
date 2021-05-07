using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Suppliers.Base.Entities;

namespace InventoryManagement.Base.Entities
{
    /// <summary>
    /// The gift received voucher
    /// </summary>
    public class GoodReceivedVoucher : EntityBase
    {
        /// <summary>
        /// Gets or Sets the Date the order was received
        /// </summary>
        public DateTime DateReceived = DateTime.Now;
        
        [ForeignKey(nameof(Supplier))]
        public string SupplierId { get; set; }
        /// <summary>
        /// Gets or Sets the supplier that send the order
        /// </summary>
        public Supplier Supplier { get; set; }
        
        /// <summary>
        /// Gets or Sets the Details List of the Voucher
        /// </summary>
        public ICollection<GoodReceivedVoucherDetails> Details { get; set; }
    }
}
