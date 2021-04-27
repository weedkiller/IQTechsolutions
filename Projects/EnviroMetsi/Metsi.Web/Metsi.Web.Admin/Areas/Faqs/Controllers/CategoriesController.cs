using Grouping.Core.Context.Services;
using Grouping.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;

namespace Metsi.Web.Site.Admin.Areas.Faqs.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The controller for the Categories
    /// </summary>
    [Area("Faqs")]
    [Route("Faqs/[controller]/[action]")]
    public class CategoriesController : CategoryBaseController<Question>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service">The injected category service</param>
        public CategoriesController(CategoryContext<Question> service) : base(service)
        {
        }
    }
}
