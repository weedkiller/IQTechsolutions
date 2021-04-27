using System;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Calendar.Core.Models;
using Iqt.Base.Entities;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Admin.Areas.Calendar.Controllers
{
    [Area("Calendar")]
    [Route("Calendar/[controller]/[action]")]
    public class LocationsController : Controller
    {
        private DbContext _context;

        public LocationsController(DbContext context)
        {
            _context = (DbContext)context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMarkerLocationInfo(string id)
        {
            var model = _context;

            return PartialView("_AddMarkerLocation", model);
        }

        /// <summary>
        /// The default delete view
        /// GET: Employees/Home/Delete/{Id}
        /// </summary>
        /// <param name="id">The identity of the employee to be deleted</param>
        /// <returns>The default delete view</returns>
        public IActionResult AddMarkerLocation(string lat, string lng, string routeId)
        {
            var model = new AddLocationPartialModel()
            {
                Latitude = lat,
                Longitude = lng,
                RouteId = routeId
            };

            return PartialView("_AddMarkerLocation", model);
        }

        /// <summary>
        /// Post to delete the employee from the database
        /// </summary>
        /// <param name="id">The identity of the employee to be deleted</param>
        /// <returns>A json bool result to indicate whether the removal was succesful</returns>
        public async Task<IActionResult> Create(string lat, string lng, string routeId)
        {
            var model = new AddEditModelBase<RouteLocation>()
            {
                Entity = new RouteLocation()
                {
                    RouteId = routeId,
                    Address = new Address<RouteLocation>()
                    {
                        Location = new Location()
                        {
                            Latitude = Double.Parse(lat),
                            Longitude = Double.Parse(lng)
                        }
                    }
                }
            };
            // Return the Json
            return View(model);
        }

        /// <summary>
        /// Post to delete the employee from the database
        /// </summary>
        /// <param name="id">The identity of the employee to be deleted</param>
        /// <returns>A json bool result to indicate whether the removal was succesful</returns>
        [HttpPost]
        public async Task<IActionResult> Create(AddEditModelBase<RouteLocation> model, string finnish)
        {
            if (ModelState.IsValid)
            {
                _context.Set<RouteLocation>().Add(model.Entity);
                await _context.SaveChangesAsync();

                if (string.IsNullOrEmpty(finnish))
                {
                    return RedirectToAction("Edit", "Locations", new { area = "Calendar", id = model.Entity.Id });
                }
                return RedirectToAction("Edit", "Routes", new {area = "Calendar", id = model.Entity.RouteId});
            }
            // Return the Json
            return View(model);
        }

        public async Task<IActionResult> Edit(string id, string lat, string lng)
        {
            var entity = await _context.Set<RouteLocation>().Include(c => c.Tasks).ThenInclude(c => c.Task).Include(c => c.Address).ThenInclude(c => c.Location).FirstOrDefaultAsync(c => c.Id == id);
            if (!string.IsNullOrEmpty(lat))
            {
                entity.Address.Location.Latitude = double.Parse(lat);
            }
            if (!string.IsNullOrEmpty(lng))
            {
                entity.Address.Location.Longitude = double.Parse(lng);
            }

            var model = new AddEditModelBase<RouteLocation>(entity);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddEditModelBase<RouteLocation> model,string finnish)
        {
            if (ModelState.IsValid)
            {
                //var entity = await _context.Set<RouteLocation>().Include(c => c.Tasks).Include(c => c.Route).Include(c => c.Address).ThenInclude(c => c.Location).FirstOrDefaultAsync(c => c.Id == model.Entity.Id);


                //_context.Entry(entity).CurrentValues.SetValues(model.Entity);
                //if(entity.Address != null)
                //{
                //    _context.Entry(entity.Address).CurrentValues.SetValues(model.Entity.Address);
                //}

                _context.Update(model.Entity);

                await _context.SaveChangesAsync();
                if (!string.IsNullOrEmpty(finnish))
                {
                    return RedirectToAction("Edit","Routes",new {area="Calendar", id = model.Entity.RouteId});
                }

                return RedirectToAction("Edit", "Locations", new { area = "Calendar", id = model.Entity.Id });
            }
            return View();
        }

        
    }
}
