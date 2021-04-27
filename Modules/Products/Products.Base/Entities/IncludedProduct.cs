using System.ComponentModel.DataAnnotations.Schema;
using Products.Base.Entities;

namespace Iqt.Inventory.Entities
{
    /// <summary>
    /// The brand of the product
    /// </summary>
    public class IncludedProduct<T>
    {
        /// <summary>
        /// Gets or sets the quantity of the specific product
        /// </summary>
        public double Qty { get; set; }

        #region Properties

        /// <summary>
        /// Gets or Sets the entity that the product was applied to
        /// </summary>
        public string EntityId { get; set; }
        public T Entity { get; set; }

        /// <summary>
        /// Gets or Sets the product that was applied to the entity
        /// </summary>
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        #endregion
    }
}