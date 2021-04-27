using System.Linq;
using System.Threading.Tasks;
using Iqt.Grouping.Data;
using Iqt.Grouping.Models;
using Iqt.Troubleshooting.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Iqt.Troubleshooting.ViewComponents
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
            var model = new CategoryIndexModel<Problem>((_service.GetAllParentCategories(categoryId)).OrderBy(c => c.Modified).ToList());
            if(!string.IsNullOrEmpty(categoryId))
            {
                model.ParentId = categoryId;
            }
            return View(model);
        }
    }
}
