using Microsoft.AspNetCore.Http;
using Products.Base.Entities;

namespace Products.Core.Models
{
    /// <summary>
    /// The model used when adding a new brand
    /// </summary>
    public class ProductBrandAddEditModel
    {
        #region Constructors

        /// <summary>
        /// Default parameterless constructor
        /// </summary>
        public ProductBrandAddEditModel() { }

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="brand"></param>
        public ProductBrandAddEditModel(ProductBrand brand)
        {
            ProductBrand = brand;
        }

        #endregion

        /// <summary>
        /// The ProductBrand Featured by this model
        /// </summary>
        public ProductBrand ProductBrand { get; set; }

        /// <summary>
        /// The Identity of the Parent Entity
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// The coverImage of the Brand
        /// </summary>
        public IFormFile CoverUpload { get; set; }

        /// <summary>
        /// The Banner Image of this brand
        /// </summary>
        public IFormFile BannerUpload { get; set; }
    }
}
 