using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Education.Base.ApiModels;
using Iqt.Base.Interfaces;
using Iqt.Web;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.ApiModels;

namespace Metsi.Web.Training.ViewComponents
{
    [ViewComponent]
    public class CourseModules : ViewComponent
    {
        private IApplicationConfiguration _configuration;

        public CourseModules(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string courseId)
        {
            try
            {
                var serverResponse = await WebRequests.GetAsync<IEnumerable<ModuleApiModel>>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "modules/getmodules?courseId=" + courseId));
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
