using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web.Exceptions;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Troubleshooting.Base.ApiModels;
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
