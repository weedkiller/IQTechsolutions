using Grouping.Core.Context.Services;
using Grouping.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;

// ReSharper disable Mvc.ActionNotResolved
// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.PartialViewNotResolved

namespace Metsi.Web.Site.Admin.Areas.Troubleshooting.Controllers
{
    [Area("Troubleshooting")]
    [Route("Troubleshooting/[controller]/[action]")]
    public class CategoriesController : CategoryBaseController<Problem>
    {
        public CategoriesController(CategoryContext<Problem> service) : base(service)
        {
        }
    }
}