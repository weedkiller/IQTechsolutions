using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Employment.Base.ApiModels;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web.Exceptions;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Metsi.Web.Training.ViewComponents
{
    [ViewComponent]
    public class EmployeeSection : ViewComponent
    {
        private HttpClient _client;
        private IApplicationConfiguration _configuration;

        public EmployeeSection(IHttpClientFactory clientFactory, IApplicationConfiguration configuration)
        {
            _client = clientFactory.CreateClient();
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var response = await _client.GetAsync(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "/Employees"));
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }

                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                PagedResult<EmployeeModel> result = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<EmployeeModel>>(content));
                return View(result.Results.Take(3));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
