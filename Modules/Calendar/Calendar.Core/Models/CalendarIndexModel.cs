using System.Collections.Generic;
using Calendar.Base.Entities;

namespace Calendar.Core.Models
{
    public class CalendarIndexModel
    {
        public ICollection<RecurringTask> RecurringTasks { get; set; } = new List<RecurringTask>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
