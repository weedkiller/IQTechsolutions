using System.Collections.Generic;
using Iqt.Base.Models;
using Suppliers.Base.Entities;

namespace Suppliers.Core.Models
{
    public class SupplierIndexModel : IndexModelBase<Supplier>
    {
        public SupplierIndexModel(ICollection<Supplier> collection, int? size = null, int? page = null, int? sort = null) : base(collection, size, page, sort)
        {
        }
    }
}
