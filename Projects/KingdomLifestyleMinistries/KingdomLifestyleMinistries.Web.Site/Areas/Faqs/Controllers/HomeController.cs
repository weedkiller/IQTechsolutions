using Iqt.Troubleshooting.Controllers;
using Iqt.Troubleshooting.Services;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Faqs.Controllers
{
    [Area("Faqs")]
    [Route("Faqs/[controller]/[action]")]
    public class HomeController : FaqQuestionBaseController
    {
        /// <inheritdoc />
        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected context service</param>
        public HomeController(FaqContextService service) : base(service) { }
    }
}