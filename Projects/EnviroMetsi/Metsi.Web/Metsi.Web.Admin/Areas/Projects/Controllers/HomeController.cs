using Grouping.Core.Context.Services;
using Identity.Base.Entities;
using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projects.Base.Entities;
using Projects.Core.Context.Services;
using Projects.Core.Controllers;

namespace Metsi.Web.Admin.Areas.Projects.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The home controller of the projects area
    /// </summary>
    [Area("Projects")]
    [Route("Projects/[controller]/[action]")]
    public class HomeController : ProjectBaseController
    {
        /// <inheritdoc />
        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected context service</param>
        /// <param name="categoryContext">The injected category context service</param>
        public HomeController(ProjectsContext service, CategoryContext<Project> categoryContext) 
            : base(service, categoryContext)
        {
        }
    }
}