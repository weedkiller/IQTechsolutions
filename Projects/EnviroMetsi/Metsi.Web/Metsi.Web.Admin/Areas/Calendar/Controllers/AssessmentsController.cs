using System;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Calendar.Core.Context.Services;
using Iqt.Base.Entities;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.Areas.Calendar.Controllers
{
    [Area("Calendar")]
    [Route("Calendar/[controller]/[action]")]
    public class AssessmentsController : Controller
    {
        private readonly FormElementContext _service;

        public AssessmentsController(FormElementContext service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexModelBase<FormElement<RecurringTask>>( await _service.GetAll());
            return View(model);
        }

        /// <summary>
        /// The method to setup the create view
        /// </summary>
        /// <param name="parentId">The identity of the question this answer belongs to</param>
        /// <returns>The create view</returns>
        public async Task<IActionResult> CreateElement(string parentId)
        {
            // Create new answer
            var model = new FormElement<RecurringTask>()
            {
                Id = Guid.NewGuid().ToString(),
                EntityId = parentId
            };
            // Return the view
            return PartialView("_Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateElement(FormElement<RecurringTask> model)
        {
            await _service.AddFormElementAsync(model);
            return RedirectToAction("Edit", "Work", new {id = model.EntityId});
        }
    }
}
