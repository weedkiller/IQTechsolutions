using System.Linq;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Metsi.Web.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Admin.ViewComponents
{
    public class CalendarTaskMenu : ViewComponent
    {
        private readonly DbContext _context;

        public CalendarTaskMenu(DbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new CalendarTaskMenuModel()
            {
                RecurringTasks = await _context.Set<RecurringTask>().Where(c => c.ParentTaskId == null)
                    .Where(c => c.ListedCalendarItem).ToListAsync(),
                Routes = await _context.Set<Route>().ToListAsync()
            };

            return View(model);
        }
    }
}
