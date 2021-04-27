using Customers.Base.Entities;
using Iqt.Base.Models;

namespace Customers.Core.Models
{
    public class AffiliateDetailsModel : DetailsModelBase<Affiliate>
    {
        public AffiliateDetailsModel(Affiliate entity) : base(entity)
        {
        }
    }
}
