using Iqt.Base.Models;
using Suppliers.Base.Entities;

namespace Suppliers.Core.Models
{
    public class SupplierDetailsModel : DetailsModelBase<Supplier>
    {
        public SupplierDetailsModel(Supplier entity) : base(entity)
        {
        }
    }
}
