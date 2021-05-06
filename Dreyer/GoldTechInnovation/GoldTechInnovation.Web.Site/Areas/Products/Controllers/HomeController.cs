using Grouping.Core.Context.Services;
using Microsoft.AspNetCore.Mvc;
using Products.Base.Entities;
using Products.Core.Context.Services;
using Products.Core.Controllers;

namespace GoldTechInnovation.Web.Site.Areas.Products.Controllers
{
    [Area("Products")]
    [Route("Products/{controller=home}/{action=index}")]
    public class HomeController : ProductBaseController
    {
        public HomeController(ProductContext service, CategoryContext<Product> categoryService) : base(service, categoryService)
        {
        }
    }
}
