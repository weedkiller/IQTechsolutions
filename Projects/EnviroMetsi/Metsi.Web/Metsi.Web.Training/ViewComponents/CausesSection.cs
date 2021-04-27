using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.ApiModels;
using Troubleshooting.Base.Models.ApiModels;

namespace Metsi.Web.Training.ViewComponents
{
    [ViewComponent]
    public class CausesSection : ViewComponent
    {
        private IApplicationConfiguration _configuration;

        public CausesSection(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string problemId)
        {
            try
            {
                var serverResponse = await WebRequests.GetAsync<IEnumerable<CauseResultModel>>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "causes/getall?problemId=" + problemId));
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
