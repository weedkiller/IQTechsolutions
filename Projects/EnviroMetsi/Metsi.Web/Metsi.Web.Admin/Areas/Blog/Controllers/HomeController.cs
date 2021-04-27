using Blogging.Base.Entities;
using Blogging.Core.Context.Services;
using Blogging.Core.Controllers;
using Grouping.Core.Context.Services;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Site.Admin.Areas.Blog.Controllers
{
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
        /// <param name="categoryService">The injected category service</param>
        public HomeController(BlogContext service, CategoryContext<BlogPost> categoryService) 
            : base(service, categoryService)
        {
        }
    }
}