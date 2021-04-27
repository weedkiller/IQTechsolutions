using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grouping.Base.Models;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web;
using Iqt.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Training.ViewComponents
{
    [ViewComponent]
    public class ProblemCategorySection : ViewComponent
    {
        private IApplicationConfiguration _configuration;

        public ProblemCategorySection(IApplicationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string parentId)
        {
            try
            {
                var serverResponse = await WebRequests.GetAsync<IEnumerable<CategoryModel>>(RouteHelpers.GetAbsoluteRoute(_configuration.BaseApiUrl, $"problemcategories/getlist?parentId={parentId}"));
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
