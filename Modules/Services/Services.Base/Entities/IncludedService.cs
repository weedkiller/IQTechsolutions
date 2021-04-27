using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Base.Entities
{
    /// <summary>
    /// This is the many to many part of an Entity Service Setup
    /// which lets a entity contain multiple services
    /// and a service can belong to multiple entities
    /// </summary>
    public class IncludedService<T>
    {
        /// <summary>
        /// Gets or sets the quantity of the specific service
        /// </summary>
        public double Qty { get; set; }

        #region Properties

        /// <summary>
        /// Gets or Sets the entity that the service was applied to
        /// </summary>
        public string EntityId { get; set; }
        public T Entity { get; set; }

        /// <summary>
        /// Gets or Sets the service that was applied to the entity
        /// </summary>
        [ForeignKey("Service")]
        public string ServiceId { get; set; }
        public Service Service { get; set; }

        #endregion
    }
}
