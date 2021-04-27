using System.Net.Http;
using System.Threading.Tasks;
using Education.Base.ApiModels;
using Iqt.Base.Interfaces;
using Iqt.Web;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Training.Areas.Courses.Controllers
{
    [Area("Courses")]
    [Route("Courses/[controller]/[action]")]
    public class ModulesController : Controller
    {
        private IApplicationConfiguration _configuration;
        private readonly HttpClient _client;

        /// <summary>
        /// Default Construction
        /// </summary>
        /// <param name="clientFactory">The injected <see cref="IHttpClientFactory"/></param>
        /// <param name="configuration">The injected <see cref="IApplicationConfiguration"/></param>
        public ModulesController(IHttpClientFactory clientFactory, IApplicationConfiguration configuration)
        {
            this._configuration = configuration;
            _client = clientFactory.CreateClient();
        }

        public async Task<IActionResult> Index(string moduleId)
        {
            var moduleDetailResponse = await WebRequests.GetAsync<ModuleApiModel>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, $"Modules/GetModule?moduleId={moduleId}"));
            var model = moduleDetailResponse.ServerResponse;
            
            return View(model);
        }


    }
}
