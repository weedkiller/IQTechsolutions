using System.Collections.Generic;
using Calendar.Base.Entities;

namespace Metsi.Web.Admin.Models
{
    public class CalendarTaskMenuModel
    {
        public IEnumerable<RecurringTask> RecurringTasks { get; set; } = new List<RecurringTask>();
        public IEnumerable<Route> Routes { get; set; } = new List<Route>();
    }
}
