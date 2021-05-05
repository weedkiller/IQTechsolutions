using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldTechInnovation.Web.Site.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct { get; }

        Product GetProductById(string productId);
    }
}
