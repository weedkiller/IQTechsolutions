using Education.Base.Entities;
using Iqt.Base.Models;

namespace Education.Core.Models
{
    /// <summary>
    /// The base <see cref="Section"/> controller
    /// </summary>
    public class SectionDetailsModel : DetailsModelBase<Section>
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="entity">The <see cref="Section"/> featured by this model</param>
        public SectionDetailsModel(Section entity) : base(entity)
        {
        }
    }
}
