using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;
using Products.Base.Entities;

namespace Products.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The model used when adding a new Product
    /// </summary>
    public class BrandAddEditModel : AddEditModelBase<Brand>
    {
        #region Constructors   

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BrandAddEditModel() : base(new Brand()) { }

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor with brand parameter
        /// </summary>
        /// <param name="brand">The brand used to constuct the model</param>
        public BrandAddEditModel(Brand brand) : base(brand) { }
        
        #endregion

        /// <summary>
        /// The coverImage of the Product about to be uploaded
        /// </summary>
        public IFormFile CoverUpload { get; set; }
    }
}
