using System.Collections.Generic;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Troubleshooting.Base.Entities;

namespace Troubleshooting.Core.Models
{
    public class FaqIndexModel : IndexModelBase<Question>
    {
        public FaqIndexModel(ICollection<Question> collection, int? size = null, int? page = null) : base(collection, size, page)
        {
        }

        public ICollection<Category<Question>> Categories { get; set; } = new List<Category<Question>>();
    }
}
