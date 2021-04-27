using System.Collections.Generic;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Education.Base.Entities;
using Grouping.Core.Context.Services;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.ViewComponents
{
    [ViewComponent]
    public class TasksToComplete : ViewComponent
    {
        private CategoryContext<Course> _service;

        public TasksToComplete(CategoryContext<Course> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            return View(new List<RecurringTask>());
        }
    }
}
