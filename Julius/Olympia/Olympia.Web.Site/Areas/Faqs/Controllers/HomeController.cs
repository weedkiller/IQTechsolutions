using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Core.Context.Services;
using Troubleshooting.Core.Controllers;

namespace Olympia.Web.Site.Areas.Faqs.Controllers
{
    [Area("Faqs")]
    [Route("Faqs/[controller]/[action]")]
    public class HomeController : QuestionBaseController
    {
        public HomeController(FaqContext service) : base(service)
        {
        }
        public IActionResult Faqs()
        {
            return View();
        }

    }
}
