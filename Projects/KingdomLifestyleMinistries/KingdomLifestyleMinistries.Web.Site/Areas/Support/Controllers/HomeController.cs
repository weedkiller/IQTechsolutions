using GoogleReCaptcha.V3.Interface;
using Iqt.Core.Controllers;
using Iqt.Feedback.Services;
using Iqt.Identity.Entities;
using Iqt.MailingService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Support.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The home controller for ticketing system
    /// </summary>
    [Area("Support")]
    [Route("Support/[controller]/[action]")]
    public class HomeController : TicketBaseController<ApplicationUser>
    {
        /// <inheritdoc />
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="service">The injected context service</param>
        /// <param name="leadService">The injected lead data service</param>
        /// <param name="emailSender">The injected email sender</param>
        public HomeController(TicketContextService<ApplicationUser> service, IEmailTemplateSender emailSender, ICaptchaValidator captchaValidator) : base(service, emailSender, captchaValidator)
        {
        }
    }
}
