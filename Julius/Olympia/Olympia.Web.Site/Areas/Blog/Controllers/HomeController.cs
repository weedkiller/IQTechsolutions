using Blogging.Base.Entities;
using Blogging.Core.Context.Services;
using Blogging.Core.Controllers;
using Grouping.Core.Context.Services;
using Microsoft.AspNetCore.Mvc;

namespace Olympia.Web.Site.Areas.BlogPosts.Controllers
{
    [Area("Blog")]
    [Route("Blog/[controller]/[action]")]
    public class HomeController : BlogBaseController
    {
        
        public HomeController(BlogContext service, CategoryContext<BlogPost> categoryService) : base(service, categoryService)
        {
        }
    }
}
