using GoogleReCaptcha.V3.Interface;
using Iqt.Core.Controllers;
using Iqt.Feedback.Entities;
using Iqt.Feedback.Services;
using Iqt.MailingService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Prayer.Controllers
{
    /// <summary>
    /// The home controller for ticketing system
    /// </summary>
    [Area("Prayer")]
    [Route("Prayer/[controller]/[action]")]
    public class HomeController : TicketBaseController<PrayerRequest>
    {
        /// <inheritdoc />
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="service">The injected context service</param>
        /// <param name="emailSender">The injected email template sender</param>
        /// <param name="captchaValidator">The injected google captcha validator</param>
        public HomeController(TicketContextService<PrayerRequest> service, IEmailTemplateSender emailSender, ICaptchaValidator captchaValidator) : base(service, emailSender, captchaValidator)
        {
        }
    }
}
