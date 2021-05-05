using GoldTechInnovation.Web.Datastores;
using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
