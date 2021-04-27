using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Blogging.Base.ApiModels;
using Customers.Base.ApiModels;
using Iqt.Base.Interfaces;
using Iqt.Web.Exceptions;
using Iqt.Web.Helpers;
using Metsi.Web.Email;
using Microsoft.AspNetCore.Mvc;
using Metsi.Web.Site.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Metsi.Web.Site.Controllers
{
   public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public HomeController(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _client = clientFactory.CreateClient(); 
            _applicationConfiguration = applicationConfiguration;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Attempts to locate the view that explains the the terms and conditions for use of this website
        /// </summary>
        /// <returns>the view that explains the the terms and conditions for use of this website</returns>
        public ActionResult Terms()
        {
            return View();
        }

        /// <summary>
        /// Attempts to locate the view that explains the privacy policy
        /// </summary>
        /// <returns>the view that explains the privacy policy</returns>
        public ActionResult CookieUse()
        {
            return View();
        }

        /// <summary>
        /// Attempts to locate the view that explains the privacy policy
        /// </summary>
        /// <returns>the view that explains the privacy policy</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ComingSoon()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CustomerDetails(string id)
        {
            try
            {
                var response = _client.GetAsync(RouteHelpers.GetAbsoluteRoute(_applicationConfiguration.BaseApiUrl, "/Customers/" + id)).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }

                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                CustomerModel result = Task.Run(() => JsonConvert.DeserializeObject<CustomerModel>(content)).Result;
                return PartialView("Modals/_CustomerDetails", result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IActionResult Logout()
        {
            return SignOut("Cookie", "oidc");
        }
    }
}