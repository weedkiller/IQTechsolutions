using System.Linq;
using System.Threading.Tasks;
using Grouping.Core.Context.Services;
using Grouping.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;

namespace Metsi.Web.Admin.ViewComponents
{
    [ViewComponent]
    public class ProblemCategoryListViewComponent : ViewComponent
    {
        private CategoryContext<Problem> _service;

        public ProblemCategoryListViewComponent(CategoryContext<Problem> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            await Task.Delay(1);
            var model = new CategoryIndexModel<Problem>((_service.GetAllCategories(categoryId)).OrderBy(c => c.Modified).ToList());
            if(!string.IsNullOrEmpty(categoryId))
            {
                model.ParentCategoryId = categoryId;
            }
            return View(model);
        }
    }
}
