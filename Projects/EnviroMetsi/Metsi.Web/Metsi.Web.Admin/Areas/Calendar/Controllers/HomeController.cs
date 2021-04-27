using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Calendar.Base.Entities;
using Employment.Base.Entities;
using Metsi.Web.Admin.Areas.Calendar.Models;
using Metsi.Web.Site.Admin.Areas.Calendar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Admin.Areas.Calendar.Controllers
{
    [Area("Calendar")]
    [Route("Calendar/[controller]/[action]")]
    public class HomeController : Controller
    {
        private DbContext _context;

        public HomeController(DbContext context)
        {
            _context = context;
        }

        // GET: Home
        public ActionResult Index()
        {
            var list = new List<CalenderEmployeeModel>();
            foreach (var item in _context.Set<Employee>().ToList())
            {
                var list2 = _context.Set<Appointment>().Where(c => c.UserId == item.Id);

                var jsonlist = new List<AppointmentJsonModel>();
                foreach (var listItem in list2)
                {
                    jsonlist.Add(new AppointmentJsonModel
                    {
                        Title = listItem.Heading,
                        Description = listItem.Description,
                        Start = listItem.StartDate.ToShortDateString() + "T" + listItem.StartTime.ToString(),
                        End = listItem.StartDate.ToShortDateString() + "T" + listItem.EndTime.ToString(),
                        Url = ""
                    });
                }
                list.Add(new CalenderEmployeeModel()
                {
                    EmpId = item.Id,
                    EmpName = $"{item.Names.FirstName} {item.Names.LastName}",
                    Appointments = jsonlist
                });
            }

            var model = new CalendarModel()
            {
                Employees = list,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            return View(model);
        }
        
    }
}