using System;
using System.Threading.Tasks;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Troubleshooting.Base.Entities;
using Troubleshooting.Core.Context.Services;

// ReSharper disable Mvc.PartialViewNotResolved

// ReSharper disable Mvc.ViewNotResolved

namespace Troubleshooting.Core.Controllers
{
    [Area("Troubleshooting")]
    [Route("Troubleshooting/[controller]/[action]")]
    public class CausesBaseController : Controller
    {
        /// <summary>
        /// The Repository manger for this controller
        /// </summary>
        private readonly ProblemsContext _service;

        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected context service</param>
        public CausesBaseController(ProblemsContext service)
        {
            _service = service;
        }

        #region Create Product

        /// <summary>
        /// Gets the create view and model
        /// </summary>
        /// <returns>The create view and relevant model</returns>
        [HttpGet]
        public async Task<IActionResult> Create(string parentId)
        {
            var problem = await _service.GetAsync(parentId);
            if (problem == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this problem before adding any causes or corrective actions",
                    ControllerUrl = "/Troubleshooting/Causes/Create",
                    EntityId = problem.Id
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }

            var entity = new Cause()
            {
                ProblemId = parentId
            };

            var model = new AddEditModelBase<Cause>()
            {
                Entity = entity,
                ParentId = problem.Id
            };

            return PartialView("_Create", model);
        }

        /// <summary>
        /// Posts the create model to the server
        /// </summary>
        /// <param name="model">The model to be posted to the server</param>
        /// <returns>The relevant view and model</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]AddEditModelBase<Cause> model)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                var x = await _service.AddCauseAsync(model.Entity);
                var p = Json(x, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
                return p;
            }
            return PartialView("_Create", model);
        }

        #endregion

        #region Edit Category

        /// <summary>
        /// Gets the edit view and model
        /// </summary>
        /// <param name="id">The id of the entity to be updated</param>
        /// <returns>The edit view with the relevant model</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            // Check to see if id is populated
            if (id == null)
            {
                return NotFound();
            }

            // Finds the correct product category
            var entity = await _service.GetCauseAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new AddEditModelBase<Cause>()
            {
                Entity = entity,
                ParentId = entity.Problem.Id
            };

            return PartialView("_Edit", model);
        }

        /// <summary>
        /// Posts the edit model to the server
        /// </summary>
        /// <param name="model">The model that the post is being updated from</param>
        /// <param name="addCause">The add cause button value</param>
        /// <param name="main">The main submit button value</param>
        /// <returns>The relevan view and model</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(AddEditModelBase<Cause> model)
        {
            if (ModelState.IsValid)
            {
                var y = await _service.UpdateCauseAsync(model.Entity);
                try
                {
                    var pp = JsonConvert.SerializeObject(y, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                    var p = Json(pp);
                    return p;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return PartialView("_Edit", model);
        }

        #endregion

        #region Delete 

        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            var entity = await _service.GetCauseAsync(id);

            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete cause ? " + 
                                $"<br/> with id {entity.Id}",
                ControllerUrl = "/Troubleshooting/Causes/Delete",
                EntityId = entity.Id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            _service.RemoveCause(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
    }
}
