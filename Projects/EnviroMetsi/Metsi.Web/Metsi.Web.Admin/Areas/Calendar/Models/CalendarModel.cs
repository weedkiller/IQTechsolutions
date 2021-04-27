using System.Collections.Generic;
using Metsi.Web.Site.Admin.Areas.Calendar.Models;

namespace Metsi.Web.Admin.Areas.Calendar.Models
{
    public class CalendarModel
    {
        public List<CalenderEmployeeModel> Employees { get; set; } = new List<CalenderEmployeeModel>();
        public string UserId { get; set; }
    }

    public class CalenderEmployeeModel
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }

        public List<AppointmentJsonModel> Appointments { get; set; } = new List<AppointmentJsonModel>();
     }
}
