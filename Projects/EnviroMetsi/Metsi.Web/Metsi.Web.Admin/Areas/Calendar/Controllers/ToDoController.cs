using System;
using System.Linq;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Calendar.Core.Context.Services;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.Areas.Calendar.Controllers
{
    [Area("Calendar")]
    [Route("Calendar/[controller]/[action]")]
    public class ToDoController : Controller
    {
        private readonly TaskContext _service;

        #region Constructors

        public ToDoController(TaskContext service)
        {
            _service = service;
        }

        #endregion

        #region Index

        public IActionResult Index()
        {
            var model = new IndexModelBase<RecurringTask>(_service.GetAllRecurringTasks().ToList());
            return View(model);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            var model = new AddEditModelBase<RecurringTask>(new RecurringTask());
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEditModelBase<RecurringTask> model)
        {
            if (ModelState.IsValid)
            {
                await _service.AddRecurringTaskAsync(model.Entity);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        #endregion

        #region CreateWorkItem

        public IActionResult CreateWorkItem(string id)
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
            var model = new RecurringTask()
            {
                Id = Guid.NewGuid().ToString(),
                ParentTaskId = id
            };
            // Return the view
            return PartialView("_CreateWorkItem", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkItem(RecurringTask model)
        {
            if (ModelState.IsValid)
            {
                await _service.AddRecurringTaskAsync(model);
                return RedirectToAction(nameof(Edit), new {id = model.ParentTaskId});
            }

            return PartialView("_CreateWorkItem", model);
        }

        #endregion

        #region Edit

        public IActionResult Edit(string id)
        {
            var model = new AddEditModelBase<RecurringTask>(_service.GetRecurringTask(id));
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(RecurringTask task)
        {
            return View();
        }

        #endregion

        #region EditWorkItem

        public IActionResult EditWorkItem(string id)
        {
            var model = new AddEditModelBase<RecurringTask>(_service.GetRecurringTask(id));
            return View(model);
        }

        [HttpPost]
        public IActionResult EditWorkItem(RecurringTask task)
        {
            return View();
        }

        #endregion

        [HttpPost]
        public IActionResult ChangeToDoItemStatus(bool status)
        {
            return View();
        }
    }
}
