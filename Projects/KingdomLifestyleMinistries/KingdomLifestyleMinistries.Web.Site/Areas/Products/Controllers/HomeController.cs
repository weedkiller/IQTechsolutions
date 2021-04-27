using Iqt.Core.Controllers;
using Iqt.Grouping.Interfaces;
using Iqt.Identity.Entities;
using Iqt.Inventory.Entities;
using Iqt.Inventory.Services;
using IQTechSolutions.Base.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Products.Controllers
{
    /// <summary>
    /// The controller that controls the entry level part of the products area of the website
    /// </summary>
    [Area("Products")]
    [Route("Products/[controller]/[action]")]
    public class HomeController : ProductBaseController
    {
        public HomeController(ProductContextService service, ICategoryService<Product> categoryService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) 
            : base(service, categoryService, userManager, signInManager)
        {
        }
    }
}