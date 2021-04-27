using System.Threading.Tasks;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;
using Troubleshooting.Core.Context.Services;
using Troubleshooting.Core.Models;

namespace Metsi.Web.Site.Admin.Areas.Troubleshooting.Controllers
{
    /// <summary>
    /// The trouble shooting causes controller
    /// </summary>
    [Area("Troubleshooting")]
    [Route("Troubleshooting/[controller]/[action]")]
    public class CausesController : Controller
    {
        /// <summary>
        /// The Repository manger for this controller
        /// </summary>
        private readonly ProblemsContext _service;

        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected context service</param>
        public CausesController(ProblemsContext service)
        {
            _service = service;
        }

        #region Details

        /// <summary>
        /// Gets the edit view and model
        /// </summary>
        /// <param name="id">The id of the entity to be updated</param>
        /// <returns>The edit view with the relevant model</returns>
        public async Task<IActionResult> Details(string id)
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

            return View(entity);
        }

        #endregion

        #region Create Cause

        /// <summary>
        /// Gets the create view and model
        /// </summary>
        /// <returns>The create view and relevant model</returns>
        [HttpGet]
        public async Task<IActionResult> Create(string parentId, string returnUrl)
        {
            var problem = await _service.GetAsync(parentId);
            if (problem == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this problem before adding any causes or corrective actions",
                    ControllerUrl = "/Troubleshooting/Causes/Create",
                    EntityId = parentId
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }

            var entity = new Cause()
            {
                ProblemId = parentId
            };

            var model = new CauseAddEditViewModel()
            {
                ReturnUrl = returnUrl,
                Entity = entity,
                Problem = problem,
                ParentId = problem.Id
            };

            return View(model);
        }

        /// <summary>
        /// Posts the create model to the server
        /// </summary>
        /// <param name="model">The model to be posted to the server</param>
        /// <returns>The relevant view and model</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CauseAddEditViewModel model, string finnish, string addCorrectiveAction)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                await _service.AddCauseAsync(model.Entity);
                if (!string.IsNullOrEmpty(finnish))
                {
                    if(string.IsNullOrEmpty(model.ReturnUrl))
                        return RedirectToAction("Edit", "Home", new { id = model.Entity.ProblemId });
                    return Redirect(model.ReturnUrl);
                }
                if (!string.IsNullOrEmpty(addCorrectiveAction))
                {
                    return RedirectToAction("Create", "CorrectiveActions", new { id = model.Entity.ProblemId });
                }
            }
            return View(model);

            //      var x = await _service.AddCauseAsync(model.Cause);
            //      var p = Json(x, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver(), ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            //      return p;
        }

        #endregion

        #region Edit Category

        /// <summary>
        /// Gets the edit view and model
        /// </summary>
        /// <param name="id">The id of the entity to be updated</param>
        /// <returns>The edit view with the relevant model</returns>
        public async Task<IActionResult> Edit(string id, string returnUrl)
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

            var model = new CauseAddEditViewModel()
            {
                ReturnUrl = returnUrl,
                Entity = entity,
                ParentId = entity.Id
            };

            return View(model);
        }

        /// <summary>
        /// Posts the edit model to the server
        /// </summary>
        /// <param name="model">The model that the post is being updated from</param>
        /// <param name="addCause">The add cause button value</param>
        /// <param name="main">The main submit button value</param>
        /// <returns>The relevan view and model</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(CauseAddEditViewModel model, string finnish, string addCorrectiveAction)
        {
            if (ModelState.IsValid)
            {
                var y = await _service.UpdateCauseAsync(model.Entity);
                if (!string.IsNullOrEmpty(finnish))
                {
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                        return RedirectToAction("Edit", "Home", new { id = model.Entity.ProblemId });
                    return Redirect(model.ReturnUrl);
                }
                if (!string.IsNullOrEmpty(addCorrectiveAction))
                {
                    return RedirectToAction("Create", "CorrectiveActions", new { id = model.Entity.ProblemId });
                }
            }
            return View(model);
        }

        #endregion

        #region Delete 

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
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _service.RemoveCause(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
    }
}