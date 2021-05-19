using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Base.Entities;

namespace GoldTechSolutions.Web.Site.Models
{
    public class ProductComponentModel
    {
        public string WidgetTitle { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
