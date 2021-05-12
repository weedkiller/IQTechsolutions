using System.Collections.Generic;

namespace GoldTechInnovation.Web.Site.Models
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAllBrands { get; }
    }
}
