using System.ComponentModel.DataAnnotations.Schema;

namespace Grouping.Base.Entities
{
    /// <summary>
    /// The many to many Relationship between category and <see cref="T"/>
    /// </summary>
    /// <typeparam name="T">The object that belongs to this category</typeparam>
    public class EntityCategory<T>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public EntityCategory() { }

        /// <summary>
        /// Constructor with keys for parameters
        /// </summary>
        /// <param name="entityId">The identity of the entity that is being categorized</param>
        /// <param name="categoryId">The category this entity is being categorized into</param>
        public EntityCategory(string entityId, string categoryId)
        {
            EntityId = entityId;
            CategoryId = categoryId;
        }

        #endregion

        /// <summary>
        /// The Entity that is being categorized
        /// </summary>
        [ForeignKey(nameof(T))]
        public string EntityId { get; set; }
        public T Entity { get; set; }

        /// <summary>
        /// Gets or Sets the <see cref="Category{T}"/> this entity is being categorized into
        /// </summary>
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public Category<T> Category { get; set; }
    }
}
