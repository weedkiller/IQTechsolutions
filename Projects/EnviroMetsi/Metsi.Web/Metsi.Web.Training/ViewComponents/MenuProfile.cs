using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Identity.Base.ApiModels;
using Iqt.Base.Interfaces;
using Iqt.Web.Exceptions;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Metsi.Web.Training.ViewComponents
{
    [ViewComponent]
    public class MenuProfile : ViewComponent
    {
        private HttpClient _client;
        private IApplicationConfiguration _configuration;

        public MenuProfile(IHttpClientFactory clientFactory, IApplicationConfiguration configuration)
        {
            _client = clientFactory.CreateClient();
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var response = await _client.GetAsync(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "/UserInfo/" + ((ClaimsPrincipal) User).FindFirstValue(ClaimTypes.NameIdentifier)));
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }

                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                UserInfoModel result = await Task.Run(() => JsonConvert.DeserializeObject<UserInfoModel>(content));
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
