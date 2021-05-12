using System.Collections.Generic;

namespace GoldTechInnovation.Web.Site.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories { get; }
    }
}
