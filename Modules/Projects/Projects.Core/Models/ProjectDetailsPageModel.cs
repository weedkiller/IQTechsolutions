using System.Collections.Generic;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Projects.Base.Entities;

namespace Projects.Core.Models
{
    public class ProjectDetailsPageModel : DetailsModelBase<Project>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="entity">The entity this model is based on</param>
        public ProjectDetailsPageModel(Project entity) : base(entity)
        {
        }

        #region Collections

        /// <summary>
        /// A list of active service categories available in this application
        /// </summary>
        public IEnumerable<EntityCategory<Project>> Categories { get; set; }

        /// <summary>
        /// A list of featured blog entries
        /// </summary>
        public IEnumerable<Project> FeaturedProjects { get; set; }

        /// <summary>
        /// A list of web tags associated with the featured blog entry
        /// </summary>
        public string Tags { get; set; }

        #endregion

        
    }
}
