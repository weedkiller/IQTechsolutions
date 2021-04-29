using System.Collections.Generic;
using Blogging.Base.Entities;
using Grouping.Base.Entities;
using Grouping.Core.Models;

namespace Blogging.Core.Models
{
    public class CaseStudyCategoryDetailsPageModel : CategoryDetailsModel<CaseStudy>
    {
        public CaseStudyCategoryDetailsPageModel(Category<CaseStudy> entity) : base(entity)
        {
        }

        /// <summary>
        /// A list of active case study categories available in this application
        /// </summary>
        public IEnumerable<Category<CaseStudy>> BlogCategories { get; set; }

        /// <summary>
        /// A list of featured case study entries
        /// </summary>
        public IEnumerable<CaseStudy> FeaturedBlogEntries { get; set; }

        /// <summary>
        /// A list of the most recent case study entries
        /// </summary>
        public IEnumerable<CaseStudy> RecentBlogEntries { get; set; }

        /// <summary>
        /// A list of web tags associated with the featured case study category
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// A url for the most popular video
        /// </summary>
        public string PopularVideoUrl { get; set; }

        /// <summary>
        /// The previous case study entry in the list if not first, else null
        /// </summary>
        public CaseStudy PreviousBlogEntry { get; set; }

        /// <summary>
        /// The previous case study entry in the list if not first, else null
        /// </summary>
        public CaseStudy NextBlogEntry { get; set; }
    }
}
