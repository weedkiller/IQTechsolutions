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
using Troubleshooting.Base.ApiModels;
using Troubleshooting.Base.Entities;

namespace Metsi.Web.Site.Areas.Faqs.Controllers
{
    [Area("Faqs")]
    [Route("Faqs/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public HomeController(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
            _client = clientFactory.CreateClient();
        }

        /// <summary>
        /// Set up the index model and view
        /// </summary>
        /// <param name="month">The month to filter by</param>
        /// <param name="size">The size fo the page</param>
        /// <param name="page">The page number</param>
        /// <returns>the index view</returns>
        public async Task<IActionResult> Index(int? month, string category, string tagString, int? size, int? page)
        {
            try
            {
                var response = await _client.GetAsync(RouteHelpers.GetAbsoluteRoute(_applicationConfiguration.BaseApiUrl, "/Faqs"));
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }

                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                PagedResult<QuestionModel> result = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<QuestionModel>>(content));
                return View(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}