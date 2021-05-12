using Blogging.Base.Entities;
using Blogging.Core.Context.Services;
using Microsoft.AspNetCore.Mvc;
using Blogging.Core.Controllers;
using Grouping.Core.Context.Services;

namespace GoldTechInnovation.Web.Site.Areas.Blog.Controllers
{

    [Area("Blog")]
    [Route("Blog/{controller=Home}/{action=Index}")]
    public class HomeController : BlogBaseController
    {
        public HomeController(BlogContext service, CategoryContext<BlogPost> categoryService) : base(service, categoryService)
        {
        }
    }
}
