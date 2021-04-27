using System.Collections.Generic;
using Grouping.Base.Entities;
using Projects.Base.Entities;

namespace Projects.Core.Models
{
    public class ProjectCategoryDetailsModel
    {
        #region Constructors

        public ProjectCategoryDetailsModel(EntityCategory<Project> entity)
        {
            Entity = entity;
        }

        #endregion

        /// <summary>
        /// The previous blog entry in the list if not first, else null
        /// </summary>
        public EntityCategory<Project> Entity { get; set; }

        /// <summary>
        /// The previous blog entry in the list if not first, else null
        /// </summary>
        public EntityCategory<Project> Previous { get; set; }

        /// <summary>
        /// The previous blog entry in the list if not first, else null
        /// </summary>
        public EntityCategory<Project> Next { get; set; }

        #region Service Lists

        /// <summary>
        /// A list of featured blog entries
        /// </summary>
        public IEnumerable<Project> FeaturedProjects { get
        {
            foreach (EntityCategory<Project> c in Entity.Category.EntityCollection)
            {
                if (c.Category.Featured) yield return null;
            }
        } }

        #endregion

        #region Collections

        /// <summary>
        /// A list of active project categories available in this application
        /// </summary>
        public ICollection<EntityCategory<Project>> Categories { get; set; }

        #endregion
        
    }
}