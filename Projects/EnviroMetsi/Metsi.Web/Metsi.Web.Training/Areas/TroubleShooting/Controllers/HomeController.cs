using System.Collections.Generic;
using System.Threading.Tasks;
using Employment.Base.ApiModels;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Troubleshooting.Base.ApiModels;
using Troubleshooting.Base.Entities;
using Troubleshooting.Base.Models.ApiModels;

namespace Metsi.Web.Training.Areas.TroubleShooting.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The Troubleshooting problem controller
    /// </summary>
    [Area("Troubleshooting")]
    [Route("Troubleshooting/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IApplicationConfiguration _configuration;

        public HomeController(IApplicationConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            var serverResponse = await WebRequests.GetAsync<ProblemResultModel>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "problems/" + id));
            return View(serverResponse.ServerResponse);
        }
    }
}