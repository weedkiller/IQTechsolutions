using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Core.Context.Services;
using Troubleshooting.Core.Controllers;

namespace Metsi.Web.Site.Admin.Areas.Faqs.Controllers
{
    /// <summary>
    /// The controller for the faq answers
    /// </summary>
    [Area("Faqs")]
    [Route("Faqs/[controller]/[action]")]
    public class AnswersController : AnswerBaseController
    {
        /// <inheritdoc />
        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected context service</param>
        /// <param name="fileFactory">The injected file factory</param>
        public AnswersController(FaqContext service) : base(service) { }
    }
}
