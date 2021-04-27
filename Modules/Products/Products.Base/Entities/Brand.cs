using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Filing.Base.Entities;

namespace Products.Base.Entities
{
    /// <summary>
    /// The brand of the product
    /// </summary>
    public class Brand : ImageFileCollection<Brand>
    {
        #region Public Properties

        /// <summary>
        /// The name of the Brand
        /// </summary>
        [DisplayName("Brand"), Required(ErrorMessage = @"Please enter a name for this product brand")]
        public string Name { get; set; }

        /// <summary>
        /// The slogan of the brand
        /// </summary>
        [DisplayName("Slogan"), DataType(DataType.MultilineText)]
        public string Slogan { get; set; }

        /// <summary>
        /// The Description of the brand
        /// </summary>
        [DisplayName("Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        #endregion

        #region Collections

        /// <summary>
        /// A list of web tags for this product
        /// </summary>
        public string WebTags { get; set; }


        /// <summary>
        /// A list of Product Brands that belongs to this brand
        /// </summary>
        public virtual ICollection<ProductBrand> ProductBrands { get; set; } = new List<ProductBrand>();

        ///// <summary>
        ///// A list of listingbrands that belongs to this brand
        ///// </summary>
        //public virtual ICollection<BrandReview> Reviews { get; set; } = new List<BrandReview>();

        #endregion

    }

}