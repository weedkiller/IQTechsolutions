using Iqt.Base.Interfaces;

namespace Iqt.Base.Models
{
    public class DetailsModelBase<TEntity> : EntityModelBase<TEntity> where TEntity : IEntityBase
    {
        public DetailsModelBase(TEntity entity) : base(entity)
        {
        }

        /// <summary>
        /// The previous blog entry in the list if not first, else null
        /// </summary>
        public TEntity Previous { get; set; }

        /// <summary>
        /// The previous blog entry in the list if not first, else null
        /// </summary>
        public TEntity Next { get; set; }
    }
}
