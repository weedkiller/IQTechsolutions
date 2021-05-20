using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Education.Base.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Education.Base.Entities;
using Iqt.Base.Interfaces;
using Iqt.Web;
using Iqt.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Syncfusion.EJ2.ProgressBar;

namespace Metsi.Web.Training.Areas.Courses.Controllers
{
    [Area("Courses")]
    [Route("Courses/[controller]/[action]")]
    public class HomeController : Controller
    {
        private IApplicationConfiguration _configuration;
        private readonly HttpClient _client;

        /// <summary>
        /// Default Construction
        /// </summary>
        /// <param name="clientFactory">The injected <see cref="IHttpClientFactory"/></param>
        /// <param name="configuration">The injected <see cref="IApplicationConfiguration"/></param>
        public HomeController(IHttpClientFactory clientFactory, IApplicationConfiguration configuration)
        {
            this._configuration = configuration;
            _client = clientFactory.CreateClient();
        }

        /// <summary>
        /// Gets a list of all the Student Courses
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index(string studentId)
        {
            var serverResponse = await WebRequests.GetAsync<IEnumerable<StudentCourseApiModel>>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, $"studentcourse?studentId={studentId}"));
            return View(serverResponse.ServerResponse);
        }

        // GET: HomeController/Details/5
        public async Task<ActionResult> Details(string studentId, string courseId)
        {
            var serverResponse = await WebRequests.GetAsync<StudentCourseApiModel>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, $"studentcourse/getdetails/?studentId={studentId}&courseId={courseId}"));
            return View(serverResponse.ServerResponse);
        }
    }


    public class SkuAliases
    {
        public int SkuAliasId { get; set; }
        public int SkuAliasTypeId { get; set; }
        public string SkuAlias { get; set; }
    }


}
