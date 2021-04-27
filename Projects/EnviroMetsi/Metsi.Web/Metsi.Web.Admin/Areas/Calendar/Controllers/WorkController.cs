using System;
using System.Linq;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Calendar.Core.Context.Services;
using Calendar.Core.Models;
using Iqt.Base.Models;
using Metsi.Web.Admin.Areas.Calendar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Metsi.Web.Admin.Areas.Calendar.Controllers
{
    [Area("Calendar")]
    [Route("Calendar/[controller]/[action]")]
    public class WorkController : Controller
    {
        private readonly TaskContext _service;

        #region Constructors

        public WorkController(TaskContext calenderService)
        {
            _service = calenderService;
        }

        #endregion

        #region Index

        public IActionResult Index()
        {
            var model = new IndexModelBase<RecurringTask>(_service.GetAllParentTasks().ToList());
            return View(model);
        }

        #endregion

        #region Create

        public IActionResult Create(string routeId)
        {
            var model = new RecurringTaskAddEditModel()
            {
                Entity = new RecurringTask(),
                RouteLocationId = routeId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecurringTaskAddEditModel model, string main)
        {
            if (ModelState.IsValid)
            {
                await _service.AddRecurringTaskAsync(model.Entity);

                if(!string.IsNullOrEmpty(model.RouteLocationId))
                {
                    try
                    {
                        await _service.AddLocationTaskAsync(model.RouteLocationId, model.Entity.Id);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    
                    return RedirectToAction("Edit", "Locations", new { area = "Calendar", id = model.RouteLocationId });
                }

                
                if (!string.IsNullOrEmpty(main))
                {
                    
                    return RedirectToAction("Edit", "Work", new {area = "Calendar", id = model.Entity.Id});
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        #endregion

        #region CreateWorkItem

        public IActionResult CreateWorkItem(string id, string routeId)
        {
            var question = _service.GetRecurringTask(id);
            if (question == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this problem before adding any question or corrective actions",
                    ControllerUrl = "/Troubleshooting/Causes/Delete",
                    EntityId = id
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }

            // Create new answer
            var model = new RecurringTaskAddEditModel()
            {
                Entity = new RecurringTask()
                {
                    ParentTaskId = id
                },
                RouteLocationId = routeId
            };
            // Return the view
            return PartialView("_CreateWorkItem", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkItem(RecurringTaskAddEditModel model)
        {
            await _service.AddRecurringTaskAsync(model.Entity);
            return RedirectToAction(nameof(Edit), new {id = model.Entity.Id});
        }

        #endregion

        #region Edit

        public IActionResult Edit(string id, string routeId)
        {
            var model = new RecurringTaskAddEditModel()
            {
                Entity = _service.GetRecurringTask(id),
                RouteLocationId = routeId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecurringTaskAddEditModel model, string main)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateRecurringTaskAsync(model.Entity);

                if(!string.IsNullOrEmpty(model.RouteLocationId))
                {
                    if (!string.IsNullOrEmpty(main))
                    {
                        return RedirectToAction("Edit", "Work", new { area = "Calendar", id = model.Entity.Id, routeId = model.RouteLocationId });
                    }
                    return RedirectToAction("Edit", "Locations", new { area = "Calendar", id = model.RouteLocationId });
                }

                if (!string.IsNullOrEmpty(main))
                {
                    return RedirectToAction("Edit", "Work", new { area = "Calendar", id = model.Entity.Id });
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        #endregion

        #region EditWorkItem

        public IActionResult EditWorkItem(string id, string routeId)
        {
            var model = new RecurringTaskAddEditModel()
            {
                Entity = _service.GetRecurringTask(id),
                RouteLocationId = routeId
            };
            // Return the view
            return PartialView("_EditWorkItem", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditWorkItem(RecurringTaskAddEditModel model)
        {
            await _service.UpdateRecurringTaskAsync(model.Entity);
            return RedirectToAction(nameof(Edit), new { id = model.Entity.Id, routeId = model.RouteLocationId });
        }

        #endregion

        public IActionResult AddExistingTaskModel(string locationId)
        {
            var list = _service.GetAllParentTasks();
            var location = _service.GetRoutLocation(locationId).GetAwaiter().GetResult();

            var model = new AddExistingTaskModel()
            {
                ExistingTasks = new SelectList(list, "Id", "Name"),
                RouteLocation = location
            };

            return PartialView("/Areas/Calendar/Views/Locations/_AddExistingTask.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddExistingTaskModel(string routeId, string taskId)
        {
            var model = new EntityTask<RouteLocation>()
            {
                TaskId = taskId,
                EntityId = routeId
            };
             await _service.AddLocationTaskAsync(routeId, taskId);

             return RedirectToAction("Edit", "Locations", new {id = routeId});
        }
    }
}
