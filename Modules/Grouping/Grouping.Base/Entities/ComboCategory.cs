using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grouping.Base.Entities
{
    /// <summary>
    /// A category that contains a item that can be included as a combo item
    /// </summary>
    /// <typeparam name="T">The type of entity to be included</typeparam>
    public class ComboCategory<T>
    {
        /// <summary>
        /// The quantity of combo categories to be included with a product
        /// </summary>
        public double Qty { get; set; }

        /// <summary>
        /// The item this combo category belongs to
        /// </summary>
        [ForeignKey(nameof(ComboItem))]
        public string ComboItemId { get; set; }
        public T ComboItem { get; set; }

        /// <summary>
        /// The category that contains the entity that is included as a combo item
        /// </summary>
        [ForeignKey(nameof(ComboRecipyCategory))]
        public string ComboRecipyCategoryId { get; set; }
        public Category<T> ComboRecipyCategory { get; set; }

        /// <summary>
        /// The products to be excluded from the combo category
        /// </summary>
        public ICollection<ComboExclusions<T>> Exclusions { get; set; } = new List<ComboExclusions<T>>();
    }
}
