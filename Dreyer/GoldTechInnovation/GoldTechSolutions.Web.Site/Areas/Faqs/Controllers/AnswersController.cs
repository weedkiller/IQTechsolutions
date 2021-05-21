using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Troubleshooting.Core.Context.Services;
using Troubleshooting.Core.Controllers;

namespace GoldTechSolutions.Web.Site.Areas.AdminFaqs.Controllers
{
    [Area("AdminFaqs")]
    [Route("AdminFaqs/[controller]/[action]")]
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
