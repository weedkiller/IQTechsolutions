using System.Linq;
using System.Threading.Tasks;
using Education.Base.Entities;
using Grouping.Core.Context.Services;
using Grouping.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Admin.ViewComponents
{
    [ViewComponent]
    public class CourseCategories : ViewComponent
    {
        private CategoryContext<Course> _service;

        public CourseCategories(CategoryContext<Course> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId, string departmentId)
        {
            if (!string.IsNullOrEmpty(categoryId))
            {
                var list = await _service.GetAllCategories(categoryId).OrderBy(c => c.Modified).ToListAsync();
                return View(new CategoryIndexModel<Course>(list){ParentCategoryId = categoryId});
            }
            else
            {
                var list = await _service.GetAllDepartmentCategories(departmentId).OrderBy(c => c.Modified).ToListAsync();
                return View(new CategoryIndexModel<Course>(list){ParentDepartmentId = departmentId});
            }
        }
    }
}
