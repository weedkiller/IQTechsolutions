using System.Linq;
using System.Threading.Tasks;
using Blogging.Base.Entities;
using Grouping.Core.Context.Services;
using Grouping.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogging.Core.ViewComponents
{
    [ViewComponent]
    public class CaseStudyCategoryList: ViewComponent
    {
        private CategoryContext<CaseStudy> _service;

        public CaseStudyCategoryList(CategoryContext<CaseStudy> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            await Task.Delay(1);
            var model = new CategoryIndexModel<CaseStudy>((_service.GetAllCategories(categoryId)).OrderBy(c => c.Modified).ToList());
            if (!string.IsNullOrEmpty(categoryId))
            {
                model.ParentCategoryId = categoryId;
            }
            return View(model);
        }
    }
}
