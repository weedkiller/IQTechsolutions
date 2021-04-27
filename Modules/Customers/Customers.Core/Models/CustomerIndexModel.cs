using System.Collections.Generic;
using Customers.Base.Entities;
using Iqt.Base.Models;

namespace Customers.Core.Models
{
    public class CustomerIndexModel : IndexModelBase<Customer>
    {
        public CustomerIndexModel(ICollection<Customer> collection, int? size = null, int? page = null, int? sort = null) : base(collection, size, page, sort)
        {
        }
    }
}
