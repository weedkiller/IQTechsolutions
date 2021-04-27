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
    public class CourseModuleSections : ViewComponent
    {
        private IApplicationConfiguration _configuration;

        public CourseModuleSections(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string moduleId)
        {
            try
            {
                var serverResponse = await WebRequests.GetAsync<IEnumerable<SectionApiModel>>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "modules/GetSections?moduleId=" + moduleId));
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
