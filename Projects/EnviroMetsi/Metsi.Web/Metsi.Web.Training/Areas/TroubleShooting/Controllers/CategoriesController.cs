using System.Threading.Tasks;
using Grouping.Base.Entities;
using Grouping.Base.Models;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;
using Troubleshooting.Base.Models.ApiModels;

// ReSharper disable Mvc.ActionNotResolved
// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.PartialViewNotResolved

namespace Metsi.Web.Training.Areas.TroubleShooting.Controllers
{
    [Area("Troubleshooting")]
    [Route("Troubleshooting/[controller]/[action]")]
    public class CategoriesController : Controller
    {
        private IApplicationConfiguration _configuration;

        public CategoriesController(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            var serverResponse = await WebRequests.GetAsync<CategoryModel>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, $"problemcategories/{id}"));
            return View(serverResponse.ServerResponse);
        }
    }
}