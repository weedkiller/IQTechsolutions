using Feedback.Core.Context.Services;
using Feedback.Core.Controllers;
using GoogleReCaptcha.V3.Interface;
using Identity.Base.Entities;
using Mailing.Base.Interfaces;

namespace GoldTechInnovation.Web.Site.Areas.Support.Controllers
{
    public class SupportController : TicketBaseController<UserInfo>
    {
        public SupportController(TicketContext<UserInfo> service, IEmailSender emailSender, ICaptchaValidator captchaValidator) : base(service, emailSender, captchaValidator)
        {
        }
    }
}
