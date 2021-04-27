using Iqt.Base.Models;
using Products.Base.Entities;

namespace IQTechFramework.Models.Grouping.Brands
{
    /// <summary>
    /// The base model for the brand details
    /// </summary>
    public class BrandDetailsModel<TBrand> : DetailsModelBase<TBrand> where TBrand : Brand, new()
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BrandDetailsModel() : base(new TBrand())
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Entity Constructor
        /// </summary>
        /// <param name="entity">The brand featured by this model</param>
        public BrandDetailsModel(TBrand entity) : base(entity)
        {
        }

        #endregion
    }
}
