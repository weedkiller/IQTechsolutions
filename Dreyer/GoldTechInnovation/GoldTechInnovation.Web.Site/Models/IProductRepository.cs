using System.Collections.Generic;

namespace GoldTechInnovation.Web.Site.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct { get; }

        Product GetProductById(string productId);
    }
}
