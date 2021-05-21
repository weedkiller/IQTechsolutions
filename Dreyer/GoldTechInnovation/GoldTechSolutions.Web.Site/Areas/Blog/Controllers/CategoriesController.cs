using Blogging.Base.Entities;
using Grouping.Core.Context.Services;
using Grouping.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldTechSolutions.Web.Site.Areas.Blog.Controllers
{
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
