using System.Threading.Tasks;
using Iqt.Base.Interfaces;
using Iqt.Web;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.ApiModels;

namespace Metsi.Web.Training.Areas.TroubleShooting.Controllers
{
    /// <summary>
    /// The corrective actions controller
    /// </summary>
    [Area("Troubleshooting")]
    [Route("Troubleshooting/[controller]/[action]")]
    public class CorrectiveActionsController : Controller
    {
        private IApplicationConfiguration _applicationConfiguration;

        public CorrectiveActionsController(IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
        }

        public async Task<IActionResult> Details(string id)
        {
            var serverResponse = await WebRequests.GetAsync<CorrectiveActionResultModel>(RouteHelpers.GetAbsoluteRoute(_applicationConfiguration.BaseApiUrl, "correctiveactions?id=" + id));
            return View(serverResponse.ServerResponse);
        }
    }
}