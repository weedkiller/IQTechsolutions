using System;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Site.Admin.Areas.Calendar.Controllers
{
    [Area("Calendar")]
    [Route("Calendar/[controller]/[action]")]
    public class RoutesController : Controller
    {
        private DbContext _context;

        public RoutesController(DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _context.Set<Route>().Include(c => c.RouteLocations).ToListAsync();
            var model = new IndexModelBase<Route>(list);
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new AddEditModelBase<Route>();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEditModelBase<Route> model, string finnish)
        {
            if (ModelState.IsValid)
            {
                _context.Set<Route>().Add(model.Entity);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                if (string.IsNullOrEmpty(finnish))
                {
                    return RedirectToAction("Edit", "Routes", new { area = "Calendar", id = model.Entity.Id });
                }
                return RedirectToAction("Index", "Routes", new { area = "Calendar" });
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var entity = await _context.Set<Route>().Include(c => c.RouteLocations).ThenInclude(c => c.Address).ThenInclude(c => c.Location).FirstOrDefaultAsync(c => c.Id == id);
            var model = new AddEditModelBase<Route>(entity);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddEditModelBase<Route> model, string finnish)
        {
            if (ModelState.IsValid)
            {
                _context.Set<Route>().Update(model.Entity);
                await _context.SaveChangesAsync();
                if (string.IsNullOrEmpty(finnish))
                {
                    return RedirectToAction("Edit", "Routes", new { area = "Calendar", id = model.Entity.Id});
                }
                return RedirectToAction("Index", "Routes", new { area = "Calendar" });
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
            var entity = await _context.Set<Route>().FirstOrDefaultAsync(c => c.Id == id);

            var model = new ModalModel()
            {
                HeaderString = $"Are you sure you want to delete this calendar route",
                ControllerUrl = "/Calendar/Routes/Delete",
                EntityId = entity.Id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// The delete confirmed from the modal
        /// </summary>
        /// <param name="id">The identity of the blog to be confirmed</param>
        /// <returns>returns a task of actionresult</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var entity = await _context.Set<Route>().FirstOrDefaultAsync(c => c.Id == id);
            _context.Set<Route>().Remove(entity);
            await _context.SaveChangesAsync();

            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
    }
}
