using GoldTechInnovation.Web.Datastores;
using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldTechInnovation.Web.Site.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GoldTechInnovationDBContext _goldTechInnovationDBContext;

        public CategoryRepository(GoldTechInnovationDBContext goldTechInnovationDBContext)
        {
            _goldTechInnovationDBContext = goldTechInnovationDBContext;
        }

        
        public IEnumerable<Category> GetAllCategories => _goldTechInnovationDBContext.Categories;
    }
}
