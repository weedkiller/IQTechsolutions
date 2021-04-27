using Iqt.Core.Controllers;
using Iqt.Grouping.Services;
using Iqt.Troubleshooting.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Faqs.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The controller for the Categories
    /// </summary>
    [Area("Faqs")]
    [Route("Faqs/[controller]/[action]")]
    public class CategoriesController : CategoryBaseController<FaqQuestion>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service">The injected <see cref="CategoryContextService{T}"/> for type <see cref="FaqQuestion"/></param>
        /// <param name="imageSettings">The injected category image settings</param>
        /// <param name="iconImageSettings"></param>
        public CategoriesController(CategoryContextService<FaqQuestion> service) : base(service)
        {
        }
    }
}