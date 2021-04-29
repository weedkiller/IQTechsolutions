using System.Collections.Generic;
using Blogging.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Models;

namespace Blogging.Core.Models
{
    public class CaseStudyDetailsPageModel : DetailsModelBase<CaseStudy>
    {
        #region Constuctors
        
        /// <summary>
        /// The default construcotor
        /// </summary>
        /// <param name="entity">The entity this model should be constructed with</param>
        public CaseStudyDetailsPageModel(CaseStudy entity) : base(entity)
        {
        }

        #endregion

        /// <summary>
        /// A url for the most popular video
        /// </summary>
        public string PopularVideoUrl { get; set; }

        #region Collections

        /// <summary>
        /// A list of active case study categories available in this application
        /// </summary>
        public IEnumerable<Category<CaseStudy>> CaseStudyCategories { get; set; }

        /// <summary>
        /// A list of featured case studies
        /// </summary>
        public IEnumerable<CaseStudy> FeaturedCaseStudies { get; set; }

        /// <summary>
        /// A list of the most recent case studies
        /// </summary>
        public IEnumerable<CaseStudy> RecentCaseStudies { get; set; }

        /// <summary>
        /// A list of web tags associated with the featured case study entry
        /// </summary>
        public string Tags { get; set; }

        #endregion

    }
}
