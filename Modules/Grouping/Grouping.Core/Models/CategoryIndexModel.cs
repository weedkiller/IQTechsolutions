using System.Collections.Generic;
using Grouping.Base.Entities;
using Iqt.Base.BaseTypes;
using Iqt.Base.Models;

namespace Grouping.Core.Models
{
    /// <summary>
    /// The Details model of the <see cref="Category{T}"/> details page
    /// </summary>
    public class CategoryIndexModel<TEntity> : IndexModelBase<Category<TEntity>> where TEntity : EntityBase
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="collection">The collection of entities consumed by this model</param>
        /// <param name="size">The page size</param>
        /// <param name="page">The page number</param>
        public CategoryIndexModel(ICollection<Category<TEntity>> collection, int? size = null, int? page = null) : base(collection)
        {
            All = collection;

            PageCount = page ?? 1;
            PageSize = size ?? 12;
        }

        #endregion

        /// <summary>
        /// The identity of the parent category if any
        /// </summary>
        public string ParentCategoryId { get; set; }

        /// <summary>
        /// The identity of the parent category if any
        /// </summary>
        public string ParentDepartmentId { get; set; }

        /// <summary>
        /// The text problems should be searched by
        /// </summary>
        public string SearchText { get; set; }

    }
}