﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Troubleshooting.Core.Context.Services;
using Troubleshooting.Core.Controllers;

namespace GoldTechSolutions.Web.Site.Areas.FAQs.Controllers
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
