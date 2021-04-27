using System.Collections.Generic;
using Iqt.Base.Models;
using Products.Base.Entities;

namespace Products.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The model used when adding a new brand
    /// </summary>
    public class BrandIndexModel<TBrand> : IndexModelBase<TBrand> where TBrand : Brand
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Default Contstructor
        /// </summary>
        public BrandIndexModel() : base(null)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Controller Constructor
        /// </summary>
        /// <param name="collection">The Brand Collection</param>
        /// <param name="size">The page size</param>
        /// <param name="page">The page number</param>
        public BrandIndexModel(ICollection<TBrand> collection, int? size = null, int? page = null) : base(collection, size, page)
        {
        }

        #endregion
    }
}