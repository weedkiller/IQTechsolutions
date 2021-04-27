using System.Collections.Generic;
using System.Linq;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Products.Base.Entities;

namespace Products.Core.Models
{
    public class ProductIndexModel : IndexModelBase<Product>
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="collection">Collection consumed by this model</param>
        /// <param name="size">The size of the page</param>
        /// <param name="page">The page number</param>
        public ProductIndexModel(ICollection<Product> collection, int? size = null, int? page = null, int? sort = null) : base(collection, size, page, sort)
        {
        }

        #endregion        

        #region Product Lists

        /// <summary>
        /// A list of featured blog entries
        /// </summary>
        public IEnumerable<Product> FeaturedProducts { get { return All?.Where(c => c.Featured); } }

        #endregion

        #region Collections

        /// <summary>
        /// A list of active service categories available in this application
        /// </summary>
        public ICollection<Category<Product>> Categories { get; set; } = new List<Category<Product>>();

        /// <summary>
        /// List of all the brands offered by us
        /// </summary>
        public IEnumerable<ProductBrand> FeaturedBrands { get; set; } = new List<ProductBrand>();

        

        /// <summary>
        /// A list of web tags associated with the service
        /// </summary>
        public string Tags { get; set; }

        #endregion

        
    }
}