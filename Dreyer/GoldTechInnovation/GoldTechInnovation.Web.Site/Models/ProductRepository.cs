using System.Collections.Generic;

namespace GoldTechInnovation.Web.Site.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly GoldTechInnovationDBContext _goldTechInnovationDBContext;

        public ProductRepository(GoldTechInnovationDBContext goldTechInnovationDBContext)
        {
            _goldTechInnovationDBContext = goldTechInnovationDBContext;
        }

        public IEnumerable<Product> GetAllProduct
        {
            get
            {
                return _goldTechInnovationDBContext.Products.Include(c => c.Category);
            }
        }

        public Product GetProductById(string productId)
        {
            return _goldTechInnovationDBContext.Products.FirstOrDefault(c => c.Id == productId);
        }
    }
}
