using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Troubleshooting.Core.Context.Services;

namespace Metsi.Web.Admin.ViewComponents
{
    [ViewComponent]
    public class CategoryProblemsListViewComponent : ViewComponent
    {
        private ProblemsContext _service;

        public CategoryProblemsListViewComponent(ProblemsContext service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            var list = await _service.GetCategoryProblems(categoryId).OrderBy(c => c.Entity.Modified).ToListAsync();
            return View(list);
        }
    }
}
