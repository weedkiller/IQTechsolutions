using Feedback.Core.Context.Services;
using Feedback.Core.Controllers;
using GoogleReCaptcha.V3.Interface;
using Identity.Base.Entities;
using Microsoft.AspNetCore.Mvc;
using Olympia.Web.Email;

namespace Olympia.Web.Site.Areas.Support.Controllers
{
    [Area("Support")]
    [Route("Support/[controller]/[action]")]
    public class HomeController : TicketBaseController<UserInfo>
    {
        public HomeController(TicketContext<UserInfo> service, DefaultEmailSender emailSender, ICaptchaValidator captchaValidator) : base(service, emailSender, captchaValidator)
        {
        }
      

    }
}
