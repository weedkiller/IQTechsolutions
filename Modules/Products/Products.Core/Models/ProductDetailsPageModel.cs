using System.Collections.Generic;
using Grouping.Base.Entities;
using Products.Base.Entities;

namespace Products.Core.Models
{
    public class ProductDetailsPageModel
    {
        public int Qty { get; set; } = 1;

        #region Services

        /// <summary>
        /// The blog entry featured by this model
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// The previous blog entry in the list if not first, else null
        /// </summary>
        public Product PreviousProduct { get; set; }

        /// <summary>
        /// The previous blog entry in the list if not first, else null
        /// </summary>
        public Product NextProduct { get; set; }

        #endregion

        /// <summary>
        /// A url for the most popular video
        /// </summary>
        public string PopularVideoUrl { get; set; }        

        #region Collections

        /// <summary>
        /// A list of active service categories available in this application
        /// </summary>
        public IEnumerable<Category<Product>> ProductCategories { get; set; }

        /// <summary>
        /// A list of featured blog entries
        /// </summary>
        public IEnumerable<Product> FeaturedProducts { get; set; }

        /// <summary>
        /// A list of web tags associated with the featured blog entry
        /// </summary>
        public string Tags { get; set; }

        #endregion
    }
}