using Iqt.Base.Interfaces;

namespace Iqt.Base.Models
{
    /// <summary>
    /// The base model used for any entity that gets added/edited by the application
    /// </summary>
    /// <typeparam name="TEntity">The type of entity featured by this model</typeparam>
    public class AddEditModelBase<TEntity> : EntityModelBase<TEntity> where TEntity : IEntityBase, new()
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AddEditModelBase() : base(new TEntity())
        {
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="entity">The category featured by this model</param>
        public AddEditModelBase(TEntity entity) : base(entity)
        {
        }

        /// <summary>
        /// The identity of the parent if any
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// The url the view should return to
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
