using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Core.Context.Services;
using Troubleshooting.Core.Controllers;

namespace Metsi.Web.Site.Admin.Areas.Faqs.Controllers
{
    [Area("Faqs")]
    [Route("Faqs/[controller]/[action]")]
    public class HomeController : QuestionBaseController
    {
        /// <inheritdoc />
        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected context service</param>
        public HomeController(FaqContext service) : base(service) { }
    }
}
