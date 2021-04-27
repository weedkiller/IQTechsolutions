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
using Services.Base.ApiModels;
using Services.Base.Entities;

namespace Metsi.Web.Site.ViewComponents
{
    [ViewComponent]
    public class ServicesAboutWidget : ViewComponent
    {
        private readonly HttpClient _client;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public ServicesAboutWidget(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
            _client = clientFactory.CreateClient();
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            try
            {
                var response = await _client.GetAsync(RouteHelpers.GetAbsoluteRoute(_applicationConfiguration.BaseApiUrl, "/Services"));
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }
                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                PagedResult<ServiceModel> result = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<ServiceModel>>(content));
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
