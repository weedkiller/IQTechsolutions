using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Blogging.Base.Entities;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IQTechSolutions.Web.Site.Areas.Blog.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Home Controller for the Blog Area
    /// </summary>
    [Area("Blog")]
    [Route("Blog/[controller]/[action]")]
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
                var response = await _client.GetAsync("https://localhost:5001/api/v1/Blogs");

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == HttpStatusCode.Forbidden ||
                        response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }

                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                string serialized = await response.Content.ReadAsStringAsync();

                PagedResult<BlogPost> result = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<BlogPost>>(serialized));
                return View(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Setup the blog details view with a specific blog entry
        /// </summary>
        /// <param name="id">The id of the category that needs to be displayed</param>
        /// <returns>The blog details view</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            // Test to see if the id field is populated
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var response = await _client.GetAsync(_applicationConfiguration.BaseApiUrl + "/api/v1/blogs/" + id);

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == HttpStatusCode.Forbidden ||
                        response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }

                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                string serialized = await response.Content.ReadAsStringAsync();

                BlogPost result = await Task.Run(() => JsonConvert.DeserializeObject<BlogPost>(serialized));
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
