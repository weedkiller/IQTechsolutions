using Grouping.Core.Context.Services;
using Microsoft.AspNetCore.Mvc;
using Products.Base.Entities;
using Products.Core.Context.Services;
using Products.Core.Controllers;

namespace FeawThings.Web.Admin.Areas.Products.Controllers
{
    /// <summary>
    /// The controller of the products area
    /// </summary>
    [Area("Products")]
    [Route("Products/[controller]/[action]")]
    public class HomeController : ProductBaseController
    {
        public HomeController(ProductContext service, CategoryContext<Product> categoryContext):base(service, categoryContext)
        {
        }
    }
}
