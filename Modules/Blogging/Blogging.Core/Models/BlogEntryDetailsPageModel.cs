using System.Collections.Generic;
using Blogging.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Models;

namespace Blogging.Core.Models
{
    public class BlogEntryDetailsPageModel : DetailsModelBase<BlogPost>
    {
        #region Constuctors
        
        /// <summary>
        /// The default construcotor
        /// </summary>
        /// <param name="entity">The entity this model should be constructed with</param>
        public BlogEntryDetailsPageModel(BlogPost entity) : base(entity)
        {
        }

        #endregion

        /// <summary>
        /// A url for the most popular video
        /// </summary>
        public string PopularVideoUrl { get; set; }   

        #region Collections

        /// <summary>
        /// A list of active blog categories available in this application
        /// </summary>
        public IEnumerable<Category<BlogPost>> BlogCategories { get; set; }

        /// <summary>
        /// A list of featured blog entries
        /// </summary>
        public IEnumerable<BlogPost> FeaturedBlogEntries { get; set; }

        /// <summary>
        /// A list of the most recent blog entries
        /// </summary>
        public IEnumerable<BlogPost> RecentBlogEntries { get; set; }

        /// <summary>
        /// A list of web tags associated with the featured blog entry
        /// </summary>
        public string Tags { get; set; }

        #endregion

    }
}
