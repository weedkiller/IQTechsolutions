using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;
using Products.Base.Entities;

namespace Iqt.Inventory.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The packaging of a given product
    /// </summary>
    public class Packsize : EntityBase
    {
        #region Public Properties

        /// <summary>
        /// Flag to test if this is the default object for the parent
        /// </summary>
        public bool Default { get; set; }

        /// <summary>
        /// The quantity of items in a packsize
        /// </summary>
        [DisplayName(@"Pack Size")]
        public decimal ItemQtyInPack { get; set; } = 1;

        /// <summary>
        /// The Product this item is packaged as
        /// </summary>
        [ForeignKey("PackagedProduct")]
        public string PackagedProductId { get; set; }
        public Product PackagedProduct { get; set; }

        #endregion
    }
}
