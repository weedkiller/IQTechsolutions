using System.Collections.Generic;
using Products.Base.Entities;

namespace Products.Core.Models
{
    /// <summary>
    /// The model used by views to add a feature to a entity
    /// </summary>
    public class AddBrandToEntityModel
    {
        /// <summary>
        /// The select list for the list of features 
        /// </summary>
        public ICollection<Brand> BrandList { get; set; }

        /// <summary>
        /// The identity of the entity this feature should be added to
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// The identity of the entity this feature should be added to
        /// </summary>
        public string BrandId { get; set; }

        /// <summary>
        /// The url the partial view will use to return to
        /// </summary>
        public string UrlString { get; set; }
    }
}
