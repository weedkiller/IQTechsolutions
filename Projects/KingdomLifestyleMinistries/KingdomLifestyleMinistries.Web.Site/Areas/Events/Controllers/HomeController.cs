using Iqt.Calender.Controllers;
using Iqt.Calender.Services;
using Iqt.Identity.Entities;
using IQTechSolutions.Filing.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Events.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Home Controller for the services area
    /// </summary>
    [Area("Events")]
    [Route("Events/[controller]/[action]")]
    [DisableRequestSizeLimit]
    public class HomeController : EventBaseController
    {
        public HomeController(EventContextService service, IFileFactory fileFactory, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
            : base(service, fileFactory, userManager, signInManager) { }
    }
}
