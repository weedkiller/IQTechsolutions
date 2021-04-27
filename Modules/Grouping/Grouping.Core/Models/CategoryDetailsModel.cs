using Grouping.Base.Entities;
using Iqt.Base.BaseTypes;
using Iqt.Base.Models;

namespace Grouping.Core.Models
{
    /// <summary>
    /// Model for <see cref="Category{T}"/> Details page
    /// </summary>
    /// <typeparam name="T">The <see cref="Category{T}"/> type featured</typeparam>
    public class CategoryDetailsModel<T> : DetailsModelBase<Category<T>> where T : EntityBase, new()
    {
        /// <summary>
        /// The default Constructor
        /// </summary>
        /// <param name="entity">The <see cref="Category{T}"/> type featured</param>
        public CategoryDetailsModel(Category<T> entity) : base(entity)
        {
        }

        /// <summary>
        /// The text problems should be searched by
        /// </summary>
        public string SearchText { get; set; }
    }
}