using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Calendar.Core.Models;
using Identity.Base.Entities;
using Iqt.Base.Extensions;
using Iqt.Base.Models;
using Metsi.Web.Site.Admin.Areas.Calendar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Admin.Areas.Calendar.Controllers
{
    [Area("Calendar")]
    [Route("Calendar/[controller]/[action]")]
    public class AppointmentsController : Controller
    {
        private DbContext _context;

        public AppointmentsController(DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AppointmentInfo(string id)
        {
            var appointment = await _context.Set<Appointment>().FirstOrDefaultAsync(c => c.Id == id);
            var model = new AppointmentInfoWindowModel()
            {
                Id = appointment.Id,
                StartTime = appointment.StartDate + appointment.StartTime,
                EndTime = appointment.EndDate + appointment.EndTime,
                Title = appointment.Heading,
                ShortDescription = appointment.Description.TruncateLongString(150)
            };

            return PartialView("_AppointmentInfo", model);
        }

        [HttpPost]
        public IActionResult GetUserAppointments(string id)
        {
            var userId = string.Empty;
            if (string.IsNullOrEmpty(id))
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            else
            {
                userId = id;
            }
            var list = _context.Set<Appointment>().Where(c => c.UserId == userId);

            var jsonlist = new List<AppointmentJsonModel>();
            foreach (var item in list)
            {
                jsonlist.Add(new AppointmentJsonModel
                {
                    Id = item.Id,
                    Title = item.Heading,
                    Description = item.Description,
                    Start = item.StartDate.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture),
                    End = item.StartDate.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture),
                    Url = ""
                });
            }

            return new JsonResult(jsonlist);
        }

        [HttpPost]
        public IActionResult CreateAppointment(string startdate, string enddate, string name, string description, string employeeId, string taskId, string routeId)
        {
            var userId = string.Empty;
            if (string.IsNullOrEmpty(employeeId))
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            else
            {
                userId = employeeId;
            }

            var model = new Appointment()
            {
                StartDate = DateTime.Parse(startdate).Date,
                StartTime = new TimeSpan(0,0,0),
                EndTime = new TimeSpan(23, 59, 59),
                Heading = name,
                Description = description,
                UserId = userId
            };

            //if (!string.IsNullOrEmpty(taskId))
            //{
            //    model.TaskId = taskId;
            //}

            //if (!string.IsNullOrEmpty(routeId))
            //{
            //    model.RouteId = routeId;
            //}

            try
            {
                _context.Set<Appointment>().Add(model);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

            return new JsonResult(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var appointment = await _context.Set<Appointment>().FirstOrDefaultAsync(c => c.Id == id);
            var model = new AddEditModelBase<Appointment>(appointment);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddEditModelBase<Appointment> model)
        {
            if (ModelState.IsValid)
            {
                _context.Set<Appointment>().Update(model.Entity);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        #region Delete 

        /// <summary>
        /// Opens the Delete blog entry modal
        /// </summary>
        /// <param name="id">The identity of the blog entry to be deleted</param>
        /// <returns>A task of action result</returns>
        public async Task<ActionResult> Delete(string id)
        {
            var entity = await _context.Set<Appointment>().FirstOrDefaultAsync(c => c.Id == id);

            var model = new ModalModel()
            {
                HeaderString = $"Are you sure you want to delete Blog Entry with id {entity.Id}",
                ControllerUrl = "/Appointments/Home/Delete",
                EntityId = entity.Id
            };

            return PartialView("_DeleteAppointment", model);
        }

        /// <summary>
        /// The delete confirmed from the modal
        /// </summary>
        /// <param name="id">The identity of the blog to be confirmed</param>
        /// <returns>returns a task of actionresult</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var entity = await _context.Set<Appointment>().FirstOrDefaultAsync(c => c.Id == id);
            _context.Set<Appointment>().Remove(entity);
            await _context.SaveChangesAsync();

            // Get a list of all the blog sub-categories in json format
            var y = new JsonResult(new { id = entity.Id, name = entity.Heading});
            // Return the Json
            return y;
        }

        #endregion
    }
}
