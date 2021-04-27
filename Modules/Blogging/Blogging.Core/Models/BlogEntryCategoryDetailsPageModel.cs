using System.Collections.Generic;
using Blogging.Base.Entities;
using Grouping.Base.Entities;
using Grouping.Core.Models;

namespace Blogging.Core.Models
{
    public class BlogEntryCategoryDetailsPageModel : CategoryDetailsModel<BlogPost>
    {
        public BlogEntryCategoryDetailsPageModel(Category<BlogPost> entity) : base(entity)
        {
        }

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
        /// A list of web tags associated with the featured blog category
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// A url for the most popular video
        /// </summary>
        public string PopularVideoUrl { get; set; }

        /// <summary>
        /// The previous blog entry in the list if not first, else null
        /// </summary>
        public BlogPost PreviousBlogEntry { get; set; }

        /// <summary>
        /// The previous blog entry in the list if not first, else null
        /// </summary>
        public BlogPost NextBlogEntry { get; set; }
    }
}
