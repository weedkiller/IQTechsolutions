using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.Interfaces;

namespace Filing.Base.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Any Attachment Files this application uses
    /// </summary>
    public class File : FileBase
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the Name of the File
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the description of this file
        /// </summary>
        public string Description { get; set; }

        #endregion
    }

    /// <summary>
    /// Any Attachment Files that belongs to <see cref="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">The parent entity</typeparam>
    public class File<TEntity> : File where TEntity : IEntityBase
    {
        #region Relationships

        /// <summary>
        /// The Entity this file belongs to
        /// </summary>
        [ForeignKey(nameof(Entity))]
        public string EntityId { get; set; }
        public TEntity Entity { get; set; }

        #endregion
    }
}
