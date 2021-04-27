using System.Collections.Generic;
using Calendar.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Models;

namespace Calendar.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The model for the service index page
    /// </summary>
    public class EventIndexModel : IndexModelBase<Event>
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Default Constructors
        /// </summary>
        /// <param name="collection">The service collection</param>
        /// <param name="size">The page size</param>
        /// <param name="page">The page number</param>
        public EventIndexModel(ICollection<Event> collection, int? size = null, int? page = null) : base(collection, size, page)
        {
        }

        #endregion   

        #region Properties        

        /// <summary>
        /// A url for the most popular video
        /// </summary>
        public string PopularVideoUrl { get; set; }

        #endregion

        #region Collections

        /// <summary>
        /// A list of active service categories available in this application
        /// </summary>
        public ICollection<Category<Event>> Categories { get; set; }

        /// <summary>
        /// A list of web tags associated with the service
        /// </summary>
        public string Tags { get; set; }

        #endregion
    }
}