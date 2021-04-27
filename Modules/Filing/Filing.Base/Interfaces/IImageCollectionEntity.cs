using System.Collections.Generic;
using Filing.Base.Entities;
using Iqt.Base.Interfaces;

namespace Filing.Base.Interfaces
{
    /// <summary>
    /// The interface to represent an object with an image collection
    /// </summary>
    /// <typeparam name="TEntity">The object that owns the images</typeparam>
    public interface IImageCollectionEntity<TEntity> : IEntityBase
    {
        /// <summary>
        /// The collection of images
        /// </summary>
        ICollection<ImageFile<TEntity>> Images { get; set; }
    }
}
