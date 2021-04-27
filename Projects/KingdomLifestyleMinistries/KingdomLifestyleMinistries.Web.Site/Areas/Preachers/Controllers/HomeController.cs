using Iqt.Blogging.Services;
using Iqt.Grouping.Interfaces;
using Iqt.Grouping.Services;
using Iqt.MailingService.Interfaces;
using Iqt.Social.Controllers;
using Iqt.Social.Entities;
using Iqt.Social.Services;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Preachers.Controllers
{
    [Area("Preachers")]
    [Route("Preachers/[controller]/[action]")]
    public class HomeController : PreacherBaseController
    {
        public HomeController(PreacherContextService service, BlogContextService blogService, ICategoryService<Preacher> categoryService, IEmailTemplateSender emailSender) 
            : base(service, blogService, categoryService, emailSender)
        {
        }
    }
}