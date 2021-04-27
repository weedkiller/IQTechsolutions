using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Base.ApiModels;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.ApiModels;

namespace Metsi.Web.Training.ViewComponents
{
    [ViewComponent]
    public class CourseUserSection : ViewComponent
    {
        private IApplicationConfiguration _configuration;

        public CourseUserSection(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            try
            {
                var serverResponse = await WebRequests.GetAsync<UserInfoModel>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "userinfo/userId"));
                return View(serverResponse.ServerResponse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
