using System.Collections.Generic;
using Customers.Base.Entities;
using Iqt.Base.Models;

namespace Customers.Core.Models
{
    public class AffiliateIndexModel : IndexModelBase<Affiliate>
    {
        public AffiliateIndexModel(ICollection<Affiliate> collection, int? size = null, int? page = null, int? sort = null) : base(collection, size, page, sort)
        {
        }
    }
}
