using System.Collections.Generic;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Troubleshooting.Base.Entities;

namespace Troubleshooting.Core.Models
{
    public class ProblemIndexModel : EntityCollectionModelBase<Problem>
    {
        public ProblemIndexModel(ICollection<Problem> collection, int? size = null, int? page = null) : base(collection, size, page)
        {
        }

        /// <summary>
        /// The text problems should be searched by
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// The categories available for filter
        /// </summary>
        public IEnumerable<Category<Problem>> Categories { get; set; }


    }
}
