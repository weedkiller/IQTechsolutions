using System.Collections.Generic;
using Iqt.Base.Models;
using Services.Base.Entities;

namespace Services.Core.Models
{
    /// <summary>
    /// The model used for service details views
    /// </summary>
    public class ServiceDetailsPageModel : DetailsModelBase<Service>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="entity">The service featured by this model</param>
        public ServiceDetailsPageModel(Service entity) : base(entity)
        {
        }

        #endregion

        /// <summary>
        /// Gets of Sets a list of featured services
        /// </summary>
        public List<Service> FeaturedServices { get; set; } = new List<Service>();
    }
}
