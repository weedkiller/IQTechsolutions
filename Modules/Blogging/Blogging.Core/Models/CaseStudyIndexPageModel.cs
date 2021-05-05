using System.Collections.Generic;
using Blogging.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Models;

namespace Blogging.Core.Models
{ 
    public class CaseStudyIndexPageModel : IndexModelBase<CaseStudy>
    {
        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="collection">The entity collection</param>
        /// <param name="size">The page size</param>
        /// <param name="page">The page number</param>
        public CaseStudyIndexPageModel(ICollection<CaseStudy> collection, int? size = null, int? page = null) : base(collection, size, page)
        {
        }

        #region Collections

        /// <summary>
        /// A list of active case study categories available in this application
        /// </summary>
        public IEnumerable<Category<CaseStudy>> CaseStudyCategories { get; set; } = new List<Category<CaseStudy>>();

        /// <summary>
        /// A list of featured case study entries
        /// </summary>
        public IEnumerable<CaseStudy> FeaturedCaseStudyEntries { get; set; } = new List<CaseStudy>();

        /// <summary>
        /// A list of the most recent case study entries
        /// </summary>
        public IEnumerable<CaseStudy> RecentCaseStudyEntries { get; set; } = new List<CaseStudy>();

        /// <summary>
        /// A list of web tags associated with the featured blog category
        /// </summary>
        public string Tags { get; set; }

        #endregion

        
    }
}
