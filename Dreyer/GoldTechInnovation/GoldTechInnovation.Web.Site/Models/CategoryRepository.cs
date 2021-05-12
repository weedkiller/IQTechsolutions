using System.Collections.Generic;

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
