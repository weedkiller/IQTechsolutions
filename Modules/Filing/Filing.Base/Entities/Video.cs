using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.Interfaces;

namespace Filing.Base.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Any Video Files this application uses
    /// </summary>
    public class Video : FileBase
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the name of the video
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the description of this video
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets the featured video flag
        /// </summary>
        public bool? Featured { get; set; }

        /// <summary>
        /// Gets or Sets the string that constructs a iframe for this object
        /// </summary>
        public string IFrameString { get; set; }

        #endregion
    }

    /// <summary>
    /// Any Video Files that belongs to <see cref="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">The parent entity</typeparam>
    public class Video<TEntity> : Video where TEntity : IEntityBase
    {
        #region Relationships

        /// <summary>
        /// The Entity this video belongs to
        /// </summary>
        [ForeignKey(nameof(Entity))]
        public string EntityId { get; set; }
        public TEntity Entity { get; set; }

        #endregion
    }
}
