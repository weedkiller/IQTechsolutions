using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Blogging.Base.ApiModels;
using Blogging.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web.Exceptions;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Metsi.Web.Site.ViewComponents
{
    [ViewComponent]
    public class BlogCategoriesSidebarWidget : ViewComponent
    {
        private readonly HttpClient _client;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public BlogCategoriesSidebarWidget(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
            _client = clientFactory.CreateClient();
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            try
            {
                var response = await _client.GetAsync(RouteHelpers.GetAbsoluteRoute(_applicationConfiguration.BaseApiUrl, "/BlogCategories"));
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden ||
                        response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }

                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                PagedResult<BlogCategoryModel> result = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<BlogCategoryModel>>(content));
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
