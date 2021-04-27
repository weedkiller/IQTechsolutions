using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web.Exceptions;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projects.Base.ApiModels;
using Projects.Base.Entities;

namespace Metsi.Web.Site.Areas.Projects.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The home controller of the projects area
    /// </summary>
    [Area("Projects")]
    [Route("Gallery/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public HomeController(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
            _client = clientFactory.CreateClient();
        }

        public async Task<IActionResult> Index(int? page = null, int? size = null, int? sort = null)
        {
            try
            {
                var response = await _client.GetAsync(RouteHelpers.GetAbsoluteRoute(_applicationConfiguration.BaseApiUrl, "/Projects"));
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }
                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                PagedResult<ProjectModel> result = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<ProjectModel>>(content));
                return View(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}