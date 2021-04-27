using Customers.Base.Entities;
using Iqt.Base.Models;

namespace Customers.Core.Models
{
    public class CustomerDetailsModel : DetailsModelBase<Customer>
    {
        public CustomerDetailsModel(Customer entity) : base(entity)
        {
        }
    }
}
