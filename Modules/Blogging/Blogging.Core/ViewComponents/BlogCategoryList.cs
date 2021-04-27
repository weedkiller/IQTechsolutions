using System.Linq;
using System.Threading.Tasks;
using Blogging.Base.Entities;
using Grouping.Core.Context.Services;
using Grouping.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogging.Core.ViewComponents
{
    [ViewComponent]
    public class BlogCategoryList: ViewComponent
    {
        private CategoryContext<BlogPost> _service;

        public BlogCategoryList(CategoryContext<BlogPost> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            await Task.Delay(1);
            var model = new CategoryIndexModel<BlogPost>((_service.GetAllCategories(categoryId)).OrderBy(c => c.Modified).ToList());
            if (!string.IsNullOrEmpty(categoryId))
            {
                model.ParentCategoryId = categoryId;
            }
            return View(model);
        }
    }
}
