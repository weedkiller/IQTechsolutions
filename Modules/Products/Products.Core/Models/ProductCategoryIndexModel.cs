using System.Collections.Generic;
using System.Linq;
using Grouping.Base.Entities;
using Iqt.Base.Extensions;
using Iqt.Base.Models;
using Products.Base.Entities;

namespace Products.Core.Models
{
    public class ProductCategoryIndexModel : DetailsModelBase<Category<Product>>
    {
        #region Constructors

        public ProductCategoryIndexModel(Category<Product> entity, int? size = null, int? page = null) : base(entity)
        {
            PageCount = page ?? 1;
            PageSize = size ?? 12;
  //          All = entity.Category.Products.Select(c => c.Product).ToList();
        }

        #endregion

        /// <summary>
        /// The model entity
        /// </summary>
        public ICollection<Product> All { get; set; }

        /// <summary>
        /// A paged list of all the blog entries in this application 
        /// </summary>
        public PagedResult<Product> AllPaged => All?.AsQueryable().GetPaged<Product>(PageCount, PageSize);

        #region Properties        

        /// <summary>
        /// The active page of this Model
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// The current page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The total page count of this model
        /// </summary>
        public int PageCount { get; set; }

        #endregion

        #region Product Lists

        /// <summary>
        /// A list of featured blog entries
        /// </summary>
        public IEnumerable<Product> FeaturedProducts { get; set; }

        #endregion

        #region Collections

        /// <summary>
        /// A list of active service categories available in this application
        /// </summary>
        public ICollection<Category<Product>> Categories { get; set; }

        /// <summary>
        /// List of all the brands offered by us
        /// </summary>
        public IEnumerable<ProductBrand> FeaturedBrands { get; set; }

        /// <summary>
        /// A list of web tags associated with the service
        /// </summary>
        public string Tags { get; set; }

        #endregion
    }
}
