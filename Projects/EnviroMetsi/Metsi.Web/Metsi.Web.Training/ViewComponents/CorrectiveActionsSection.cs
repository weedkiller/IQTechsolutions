using System;
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
    public class CorrectiveActionsSection : ViewComponent
    {
        private IApplicationConfiguration _configuration;

        public CorrectiveActionsSection(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string causeId)
        {
            try
            {
                var serverResponse = await WebRequests.GetAsync<PagedResult<CorrectiveActionResultModel>>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "correctiveactions?causeId=" + causeId));
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
