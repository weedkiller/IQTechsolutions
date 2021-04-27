using System.Collections.Generic;
using Blogging.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Models;

namespace Blogging.Core.Models
{ 
    public class BlogIndexPageModel : IndexModelBase<BlogPost>
    {
        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="collection">The entity collection</param>
        /// <param name="size">The page size</param>
        /// <param name="page">The page number</param>
        public BlogIndexPageModel(ICollection<BlogPost> collection, int? size = null, int? page = null) : base(collection, size, page)
        {
        }

        #region Collections

        /// <summary>
        /// A list of active blog categories available in this application
        /// </summary>
        public IEnumerable<Category<BlogPost>> BlogCategories { get; set; } = new List<Category<BlogPost>>();

        /// <summary>
        /// A list of featured blog entries
        /// </summary>
        public IEnumerable<BlogPost> FeaturedBlogEntries { get; set; } = new List<BlogPost>();

        /// <summary>
        /// A list of the most recent blog entries
        /// </summary>
        public IEnumerable<BlogPost> RecentBlogEntries { get; set; } = new List<BlogPost>();

        /// <summary>
        /// A list of web tags associated with the featured blog category
        /// </summary>
        public string Tags { get; set; }

        #endregion

        
    }
}
