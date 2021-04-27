using System.ComponentModel.DataAnnotations.Schema;

namespace Grouping.Base.Entities
{
    /// <summary>
    /// The item that should be excluded from any combo categories
    /// </summary>
    /// <typeparam name="T">The type that should be excluded</typeparam>
    public class ComboExclusions<T>
    {
        /// <summary>
        /// Gets or sets the entity to be excluded
        /// </summary>
        [ForeignKey("Exclusion")]
        public string ExclusionId { get; set; }
        public T Exclusion { get; set; }

        /// <summary>
        /// Gets or sets the combo category the product should be excluded from
        /// </summary>
        [ForeignKey("ComboCategory")]
        public string ComboCategoryId { get; set; }
        public ComboCategory<T> ComboCategory { get; set; }
    }
}
