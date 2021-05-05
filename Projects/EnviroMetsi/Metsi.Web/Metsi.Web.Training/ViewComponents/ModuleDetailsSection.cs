using System;
using System.Threading.Tasks;
using Education.Base.ApiModels;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Training.ViewComponents
{
    [ViewComponent]
    public class ModuleDetailsSection : ViewComponent
    {
        private IApplicationConfiguration _configuration;

        public ModuleDetailsSection(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string moduleId)
        {
            try
            {
                var serverResponse = await WebRequests.GetAsync<ModuleApiModel>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, $"Modules/GetModule?moduleId={moduleId}"));
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
