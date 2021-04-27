using Iqt.Base.Interfaces;

namespace Iqt.Base.Models
{
    /// <summary>
    /// The base model used for any entity that gets added/edited by the application
    /// </summary>
    /// <typeparam name="TEntity">The type of enitty featured by this model</typeparam>
    public class AddEditModelBase<TEntity> : EntityModelBase<TEntity> where TEntity : IEntityBase, new()
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="category">The category featured by this model</param>
        public AddEditModelBase() : base(new TEntity())
        {
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="category">The category featured by this model</param>
        public AddEditModelBase(TEntity entity) : base(entity)
        {
        }

        public string ParentId { get; set; }
    }
}
