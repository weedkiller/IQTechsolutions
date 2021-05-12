using System.Collections.Generic;

namespace GoldTechInnovation.Web.Site.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public string CurrentCategory { get; set; }
    }
}
