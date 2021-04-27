using Microsoft.AspNetCore.Mvc;
using Services.Core.Context.Services;
using Services.Core.Controllers;

namespace Metsi.Web.Admin.Areas.Services.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Home Controller for the services area
    /// </summary>
    [Area("Services")]
    [Route("Services/[controller]/[action]")]
    public class HomeController : ServiceBaseController
    {
        /// <inheritdoc />
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="service">The injected context service</param>
        public HomeController(ServiceContext service) : base(service) { }
       
    }
}