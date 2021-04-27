using System.Linq;
using System.Threading.Tasks;
using Grouping.Core.Context.Services;
using Grouping.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;

namespace Troubleshooting.Core.ViewComponents
{
    [ViewComponent]
    public class FaqCategoryList: ViewComponent
    {
        private CategoryContext<Question> _service;

        public FaqCategoryList(CategoryContext<Question> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            await Task.Delay(1);
            var model = new CategoryIndexModel<Question>((_service.GetAllCategories(categoryId)).OrderBy(c => c.Modified).ToList());
            if (!string.IsNullOrEmpty(categoryId))
            {
                model.ParentCategoryId = categoryId;
            }
            return View(model);
        }
    }
}
