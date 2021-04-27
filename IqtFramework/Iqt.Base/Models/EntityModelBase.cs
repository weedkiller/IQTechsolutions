namespace Iqt.Base.Models
{
    /// <summary>
    /// The base model type for any model that features a specific entity
    /// </summary>
    /// <typeparam name="TEntity">The entity type featured</typeparam>
    public abstract class EntityModelBase<TEntity>
    {
        #region Constructors

        /// <summary>
        /// Entity Constructor
        /// </summary>
        /// <param name="entity">The entity to construc the model with</param>
        protected EntityModelBase(TEntity entity)
        {
            Entity = entity;
        }

        #endregion

        /// <summary>
        /// The model entity
        /// </summary>
        public TEntity Entity { get; set; }
    }
}
