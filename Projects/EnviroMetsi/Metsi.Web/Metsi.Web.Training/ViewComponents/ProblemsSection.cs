using System;
using System.Linq;
using System.Threading.Tasks;
using Grouping.Base.Models;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Models.ApiModels;

namespace Metsi.Web.Training.ViewComponents
{
    [ViewComponent]
    public class ProblemsSection : ViewComponent
    {
        private IApplicationConfiguration _configuration;

        public ProblemsSection(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string parentId)
        {
            try
            {
                if (parentId != null)
                {
                    var serverResponse = await WebRequests.GetAsync<PagedResult<ProblemResultModel>>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "problemcategories/categoryproblems?categoryId=" + parentId));
                    return View(serverResponse.ServerResponse);
                }
                else
                {
                    var serverResponse = await WebRequests.GetAsync<PagedResult<ProblemResultModel>>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, "problems"));
                    return View(serverResponse.ServerResponse);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
