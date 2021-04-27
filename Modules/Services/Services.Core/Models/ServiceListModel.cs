using System.Collections.Generic;
using Grouping.Base.Entities;
using Services.Base.Entities;

namespace Services.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The model for the service index page
    /// </summary>
    public class ServiceListModel 
    { 
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Default Constructors
        /// </summary>
        /// <param name="collection">The service collection</param>
        /// <param name="size">The page size</param>
        /// <param name="page">The page number</param>
        public ServiceListModel(ICollection<Service> collection, ICollection<Category<Service>> categories = null)
        {
            Services = collection;
            Categories = categories;
        }

        #endregion        

        #region Service Lists

        /// <summary>
        /// Gets or sets the collection of services
        /// </summary>
        public IEnumerable<Service> Services { get; set; }

        #endregion

        #region Properties        

        public string CategoryFilterId { get; set; }

        /// <summary>
        /// Gets or sets url for the most popular video
        /// </summary>
        public string PopularVideoUrl { get; set; }

        /// <summary>
        /// Gets or sets the tags for this service
        /// </summary>
        public string Tags { get; set; }

        #endregion

        #region Collections

        /// <summary>
        /// Gets or sets the active service categories available for this service
        /// </summary>
        public ICollection<Category<Service>> Categories { get; set; }

        #endregion
    }
}