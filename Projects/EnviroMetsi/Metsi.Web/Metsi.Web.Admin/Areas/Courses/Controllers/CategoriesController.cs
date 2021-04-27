using Education.Base.Entities;
using Grouping.Core.Context.Services;
using Grouping.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.Areas.Courses.Controllers
{
    /// <summary>
    /// The training course category controller
    /// </summary>
    [Area("Courses")]
    [Route("Courses/[controller]/[action]")]
    public class CategoriesController : CategoryBaseController<Course>
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="service">The injected category context service</param>
        public CategoriesController(CategoryContext<Course> service) : base(service)
        {
        }
    }
}
