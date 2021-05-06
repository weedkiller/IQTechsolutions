﻿using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;
using Products.Base.Entities;

namespace InventoryManagement.Base.Entities
{
    /// <summary>
    /// The Goods Received Voucher Details
    /// </summary>
    public class GoodReceivedVoucherDetails :EntityBase
    {
        /// <summary>
        /// Gets or Sets the quantity that was received
        /// </summary>
        public string Qty { get; set; }

        /// <summary>
        /// Gets or Sets the product that was received
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or Sets the excluding price that it was when received
        /// </summary>
        public double PriceExcl { get; set; }

        /// <summary>
        /// Gets or Sets the vat that was paid on the product
        /// </summary>
        public double PriceVat { get; set; }

        /// <summary>
        /// Gets or Sets the including price it was when it was received
        /// </summary>
        public double PriceIncl { get; set; }

        /// <summary>
        /// The parent <see cref="GoodReceivedVoucher"/>
        /// </summary>
        [ForeignKey(nameof(GoodReceivedVoucher))]
        public string GoodReceivedVoucherId { get; set; }
        public GoodReceivedVoucher GoodReceivedVoucher { get; set; }
    }
}