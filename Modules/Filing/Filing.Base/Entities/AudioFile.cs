using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.Interfaces;

namespace Filing.Base.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Any Audio Files this application uses
    /// </summary>
    public class AudioFile : FileBase
    {
        /// <summary>
        /// Gets or Sets the Name of the audio file
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the description of this audio file
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// Any audio files that belongs to <see cref="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">The parent entity</typeparam>
    public class AudioFile<TEntity> : AudioFile where TEntity : IEntityBase
    {
        #region Relationships

        /// <summary>
        /// The Entity this audio file belongs to
        /// </summary>
        [ForeignKey(nameof(Entity))]
        public string EntityId { get; set; }
        public TEntity Entity { get; set; }

        #endregion
    }
}
