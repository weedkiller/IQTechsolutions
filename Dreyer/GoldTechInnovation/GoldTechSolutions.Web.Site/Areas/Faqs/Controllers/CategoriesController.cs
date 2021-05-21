using Grouping.Core.Context.Services;
using Grouping.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Troubleshooting.Base.Entities;

namespace GoldTechSolutions.Web.Site.Areas.Faqs.Controllers
{
    [Area("Faqs")]
    [Route("Faqs/[controller]/[action]")]
    public class CategoriesController : CategoryBaseController<Question>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service">The injected <see cref="CategoryContextService{T}"/> for type <see cref="FaqQuestion"/></param>
        /// <param name="imageSettings">The injected category image settings</param>
        /// <param name="iconImageSettings"></param>
        public CategoriesController(CategoryContext<Question> service) : base(service)
        {
        }
    }
}
