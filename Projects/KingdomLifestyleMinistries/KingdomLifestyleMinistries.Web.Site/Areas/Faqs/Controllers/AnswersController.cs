using Iqt.Troubleshooting.Controllers;
using Iqt.Troubleshooting.Services;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Faqs.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The controller for the faq answers
    /// </summary>
    [Area("Faqs")]
    [Route("Faqs/[controller]/[action]")]
    public class AnswersController : FaqAnswerBaseController
    {
        /// <inheritdoc />
        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected context service</param>
        public AnswersController(FaqContextService service) : base(service) { }
    }
}
