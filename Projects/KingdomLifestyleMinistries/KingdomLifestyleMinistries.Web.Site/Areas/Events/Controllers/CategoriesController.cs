using Iqt.Calender.Entities;
using Iqt.Core.Controllers;
using Iqt.Grouping.Services;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Events.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The controller for the Product Categories
    /// </summary>
    [Area("Events")]
    [Route("Events/[controller]/[action]")]
    public class CategoriesController : CategoryBaseController<Event>
    {
        public CategoriesController(CategoryContextService<Event> service) : base(service)
        {
        }
    }
}