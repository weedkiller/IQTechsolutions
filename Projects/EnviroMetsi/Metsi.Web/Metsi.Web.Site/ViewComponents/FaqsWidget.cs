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

namespace Metsi.Web.Site.ViewComponents
{
    [ViewComponent]
    public class FaqsWidget : ViewComponent
    {
        private readonly HttpClient _client;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public FaqsWidget(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
            _client = clientFactory.CreateClient();
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
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
