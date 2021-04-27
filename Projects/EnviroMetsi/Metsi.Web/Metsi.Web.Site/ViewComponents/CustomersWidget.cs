using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Customers.Base.ApiModels;
using Customers.Base.Entities;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Iqt.Base.Extensions;
using Iqt.Web.Helpers;

namespace Metsi.Web.Site.ViewComponents
{
    [ViewComponent]
    public class CustomersWidget : ViewComponent
    {
        private readonly HttpClient _client;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public CustomersWidget(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
            _client = clientFactory.CreateClient();
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            try
            {
                var response = await _client.GetAsync(RouteHelpers.GetAbsoluteRoute(_applicationConfiguration.BaseApiUrl, "/Customers"));
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }

                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                PagedResult<CustomerModel> result = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<CustomerModel>>(content));
                return View(result.Results.ToList().SplitList(9));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
