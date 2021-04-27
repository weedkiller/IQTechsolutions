using System.Collections.Generic;
using Iqt.Base.Interfaces;

namespace Iqt.Base.Models
{
    /// <summary>
    /// The base model for a Index Page
    /// </summary>
    /// <typeparam name="TEntity">The entity type featured</typeparam>
    public class IndexModelBase<TEntity> : EntityCollectionModelBase<TEntity> where TEntity : class, IEntityBase
    {
        /// <inheritdoc />
        /// <summary>
        /// The Default Constructor
        /// </summary>
        /// <param name="collection">The collection of entities this page consumes</param>
        /// <param name="size">The page size</param>
        /// <param name="page">The page number</param>
        public IndexModelBase(ICollection<TEntity> collection, int? size = null, int? page = null, int? sort = null) :
            base(collection, size, page, sort)
        {
        }
    }
}
