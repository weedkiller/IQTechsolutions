using Blogging.Base.Entities;
using Grouping.Core.Context.Services;
using Grouping.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Site.Admin.Areas.Blog.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The controller for the Blog Posts Categories
    /// </summary>
    [Area("Blog")]
    [Route("Blog/[controller]/[action]")]
    public class CategoriesController : CategoryBaseController<BlogPost>
    {
        /// <inheritdoc />
        /// <summary>
        /// The Default Constructor
        /// </summary>
        /// <param name="service">The injected category service</param>
        public CategoriesController(CategoryContext<BlogPost> service) 
            : base(service)
        {
        }
    }
}