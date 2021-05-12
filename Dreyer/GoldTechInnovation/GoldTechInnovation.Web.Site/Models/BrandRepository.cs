using System.Collections.Generic;

namespace GoldTechInnovation.Web.Site.Models
{
    public class BrandRepository : IBrandRepository
    {
        private readonly GoldTechInnovationDBContext _goldTechInnovationDBContext;

        public BrandRepository(GoldTechInnovationDBContext goldTechInnovationDBContext)
        {
            _goldTechInnovationDBContext = goldTechInnovationDBContext;
        }

        public IEnumerable<Brand> GetAllBrands => _goldTechInnovationDBContext.Brands;
    }
}
