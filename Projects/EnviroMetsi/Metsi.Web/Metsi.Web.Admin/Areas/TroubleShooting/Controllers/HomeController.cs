using Grouping.Core.Context.Services;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;
using Troubleshooting.Core.Context.Services;
using Troubleshooting.Core.Controllers;

namespace Metsi.Web.Admin.Areas.TroubleShooting.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The Troubleshooting problem controller
    /// </summary>
    [Area("Troubleshooting")]
    [Route("Troubleshooting/[controller]/[action]")]
    public class HomeController : ProblemsBaseController
    {
        /// <inheritdoc />
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="service">The injected context service</param>
        public HomeController(ProblemsContext service, CategoryContext<Problem> categoryService) : base(service, categoryService)
        {
        }
    }
}