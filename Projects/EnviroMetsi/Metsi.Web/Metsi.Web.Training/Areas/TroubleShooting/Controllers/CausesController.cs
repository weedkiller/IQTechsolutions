using System.Threading.Tasks;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.ApiModels;
using Troubleshooting.Base.Entities;
using Troubleshooting.Base.Models.ApiModels;
using Troubleshooting.Core.Context.Services;

namespace Metsi.Web.Training.Areas.TroubleShooting.Controllers
{
    /// <summary>
    /// The trouble shooting causes controller
    /// </summary>
    [Area("Troubleshooting")]
    [Route("Troubleshooting/[controller]/[action]")]
    public class CausesController : Controller
    {
        /// <summary>
        /// The Repository manger for this controller
        /// </summary>
        private readonly IApplicationConfiguration _configuration;

        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected context service</param>
        public CausesController(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Details

        /// <summary>
        /// Gets the edit view and model
        /// </summary>
        /// <param name="id">The id of the entity to be updated</param>
        /// <returns>The edit view with the relevant model</returns>
        public async Task<IActionResult> Details(string id)
        {
            var serverResponse = await WebRequests.GetAsync<CauseResultModel>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "causes/" + id));
            return View(serverResponse.ServerResponse);
        }

        #endregion
    }
}