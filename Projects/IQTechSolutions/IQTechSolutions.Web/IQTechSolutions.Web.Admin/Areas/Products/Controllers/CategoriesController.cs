using Grouping.Core.Context.Services;
using Grouping.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Products.Base.Entities;

namespace IQTechSolutions.Web.Admin.Areas.Products.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The controller for the Product Categories
    /// </summary>
    [Area("Products")]
    [Route("Products/[controller]/[action]")]
    public class CategoriesController : CategoryBaseController<Product>
    {
        public CategoriesController(CategoryContext<Product> service) 
            : base(service)
        {
        }
    }
}