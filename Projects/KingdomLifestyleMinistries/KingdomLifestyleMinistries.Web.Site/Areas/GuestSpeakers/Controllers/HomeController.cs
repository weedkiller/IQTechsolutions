using Iqt.Blogging.Services;
using Iqt.Grouping.Services;
using Iqt.MailingService.Interfaces;
using Iqt.Social.Controllers;
using Iqt.Social.Entities;
using Iqt.Social.Services;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.GuestSpeakers.Controllers
{
    [Area("GuestSpeakers")]
    [Route("GuestSpeakers/[controller]/[action]")]
    public class HomeController : GuestSpeakerBaseController
    {
        public HomeController(GuestSpeakerContextService service, BlogContextService blogService, CategoryContextService<GuestSpeaker> categoryService, IEmailTemplateSender emailSender) : base(service, blogService, categoryService, emailSender)
        {
        }
    }
}