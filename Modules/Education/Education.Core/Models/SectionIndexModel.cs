using System.Collections.Generic;
using Education.Base.Entities;
using Iqt.Base.Models;

namespace Education.Core.Models
{
    /// <summary>
    /// The base <see cref="Section"/> index model
    /// </summary>
    public class SectionIndexModel : IndexModelBase<Section>
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="collection">The training section collection</param>
        /// <param name="size">The amount of objects on the page</param>
        /// <param name="page">The current page</param>
        /// <param name="sort">The sort order</param>
        public SectionIndexModel(ICollection<Section> collection, int? size = null, int? page = null, int? sort = null) : base(collection, size, page, sort)
        {
        }
    }
}
