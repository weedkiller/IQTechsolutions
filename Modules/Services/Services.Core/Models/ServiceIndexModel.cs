using System.Collections.Generic;
using System.Linq;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Services.Base.Entities;

namespace Services.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The model for the service index page
    /// </summary>
    public class ServiceIndexModel : IndexModelBase<Service>
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Default Constructors
        /// </summary>
        /// <param name="collection">The service collection</param>
        /// <param name="size">The page size</param>
        /// <param name="page">The page number</param>
        public ServiceIndexModel(ICollection<Service> collection, int? size = null, int? page = null) : base(collection, size, page)
        {
        }

        #endregion        

        #region Service Lists

        /// <summary>
        /// Gets or sets the collection of featured services
        /// </summary>
        public IEnumerable<Service> FeaturedServices { get { return All?.Where(c => c.Featured); } }

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