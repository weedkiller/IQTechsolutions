using Feedback.Core.Context.Services;
using Feedback.Core.Controllers;
using GoogleReCaptcha.V3.Interface;
using Identity.Base.Entities;
using Metsi.Web.Email;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.Areas.Support.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The home controller for ticketing system
    /// </summary>
    [Area("Support")]
    [Route("Support/[controller]/[action]")]
    public class HomeController : TicketBaseController<UserInfo>
    {
        /// <inheritdoc />
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="service">The injected context service</param>
        /// <param name="emailSender">The injected email sender</param>
        public HomeController(TicketContext<UserInfo> service, DefaultEmailSender emailSender, ICaptchaValidator captchaValidator) : base(service,emailSender, captchaValidator)
        {
        }
    }
}
