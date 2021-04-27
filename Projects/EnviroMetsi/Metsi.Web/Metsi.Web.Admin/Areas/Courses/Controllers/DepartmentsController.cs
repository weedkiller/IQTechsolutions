using Education.Base.Entities;
using Grouping.Core.Context.Services;
using Grouping.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.Areas.Courses.Controllers
{
    /// <summary>
    /// The training course department controller
    /// </summary>
    [Area("Courses")]
    [Route("Courses/[controller]/[action]")]
    public class DepartmentsController : DepartmentBaseController<Course>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service"></param>
        public DepartmentsController(DepartmentContext<Course> service) : base(service)
        {
        }
    }
}
