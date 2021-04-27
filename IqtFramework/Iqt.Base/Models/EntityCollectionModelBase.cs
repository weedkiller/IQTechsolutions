using System.Collections.Generic;
using System.Linq;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;

namespace Iqt.Base.Models
{
    /// <summary>
    /// The base entity collection model, used for any models featuring a collection of entities
    /// </summary>
    /// <typeparam name="TEntity">The type of entity consumed</typeparam>
    public abstract class EntityCollectionModelBase<TEntity> where TEntity : class, IEntityBase
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="collection">The collection of entities consumed by this model</param>
        /// <param name="size">The page size</param>
        /// <param name="page">The page number</param>
        protected EntityCollectionModelBase(ICollection<TEntity> collection, int? size = null, int? page = null, int? sort = null)
        {
            SortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            PageCount = page ?? 1;
            PageSize = size ?? 12;
            All = collection;
        }

        #endregion

        /// <summary>
        /// The model entity
        /// </summary>
        public ICollection<TEntity> All { get; set; }

        /// <summary>
        /// A paged list of all the blog entries in this application 
        /// </summary>
        public PagedResult<TEntity> AllPaged => All?.AsQueryable().GetPaged<TEntity>(PageCount, PageSize);

        #region Properties        

        /// <summary>
        /// The active page of this Model
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// The current page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The total page count of this model
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// The order a product should be sorted in
        /// </summary>
        public SortOrder SortOrder { get; set; } = SortOrder.None;

        #endregion
    }
}
