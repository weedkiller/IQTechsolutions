using Iqt.Blogging.Entities;
using Iqt.Blogging.Services;
using Iqt.Core.Controllers;
using Iqt.Grouping.Interfaces;
using Iqt.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Blog.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Home Controller for the blog area
    /// </summary>
    [Area("Blog")]
    [Route("Blog/[controller]/[action]")]
    public class HomeController : BlogBaseController
    {
        /// <inheritdoc />
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="service">The injected context service</param>
        /// <param name="blogImageSettings">The injected image settings</param>
        /// <param name="userManager">The injected usermanager</param>
        /// <param name="signInManager">The injected sign in manager</param>
        public HomeController(BlogContextService service, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICategoryService<BlogPost> categoryService) 
            : base(service, userManager, signInManager, categoryService)
        {
        }
    }
}
