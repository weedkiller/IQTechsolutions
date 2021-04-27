using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Filing.Base.Interfaces;
using Iqt.Base.BaseTypes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Filing.Base.Entities
{
    /// <summary>
    /// A collection of images that belongs to a specific object
    /// </summary>
    /// <typeparam name="TEntity">The object this collection belongs to</typeparam>
    public class ImageFileCollection<TEntity> : EntityBase, IImageCollectionEntity<TEntity>
    {
        /// <summary>
        /// The image collection that belongs to this object
        /// </summary>
        public virtual ICollection<ImageFile<TEntity>> Images { get; set; } = new List<ImageFile<TEntity>>();
    }
}
