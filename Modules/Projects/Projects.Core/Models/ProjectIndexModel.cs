using System.Collections.Generic;
using System.Linq;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Projects.Base.Entities;

namespace Projects.Core.Models
{
    public class ProjectIndexModel : IndexModelBase<Project>
    {
        #region Constructors

        public ProjectIndexModel(ICollection<Project> collection, int? size = null, int? page = null) : base(collection, size, page)
        {
        }

        #endregion        

        #region Service Lists

        /// <summary>
        /// A list of featured blog entries
        /// </summary>
        public IEnumerable<Project> FeaturedProjects { get { return All?.Where(c => c.Featured); } }

        #endregion

        #region Collections

        /// <summary>
        /// A list of active service categories available in this application
        /// </summary>
        public ICollection<EntityCategory<Project>> Categories { get; set; }

        /// <summary>
        /// A list of web tags associated with the service
        /// </summary>
        public string Tags { get; set; }

        #endregion

        
    }
}