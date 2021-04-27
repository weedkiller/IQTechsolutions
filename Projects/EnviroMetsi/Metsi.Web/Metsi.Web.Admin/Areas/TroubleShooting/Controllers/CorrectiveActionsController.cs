using System.Threading.Tasks;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;
using Troubleshooting.Core.Context.Services;
using Troubleshooting.Core.Models;

namespace Metsi.Web.Site.Admin.Areas.Troubleshooting.Controllers
{
    /// <summary>
    /// The corrective actions controller
    /// </summary>
    [Area("Troubleshooting")]
    [Route("Troubleshooting/[controller]/[action]")]
    public class CorrectiveActionsController : Controller
    {
        #region Private Members

        /// <summary>
        /// The Repository manger for this controller
        /// </summary>
        private readonly ProblemsContext _service;

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected application repository manager</param>
        public CorrectiveActionsController(ProblemsContext service)
        {
            _service = service;
        }

        #endregion

        #region Create Product

        /// <summary>
        /// Gets the create view and model
        /// </summary>
        /// <returns>The create view</returns>
        public async Task<IActionResult> Create(string problemId, string causeId, string returnUrl)
        {
            var cause = await _service.GetCauseAsync(causeId);
            var problem = await _service.GetAsync(problemId);
            var model = new CorrectiveActionAddEditViewModel
            {
                ReturnUrl = returnUrl,
                Entity = new CorrectiveAction()
                {
                    CauseId = causeId
                },
                Cause = cause,
                Problem = problem
            };

            return View(model);
        }

        /// <summary>
        /// Posts the add model to the server
        /// </summary>
        /// <param name="model">the model of the entity that should be added</param>
        /// <returns>The relevant view and model</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CorrectiveActionAddEditViewModel model, string finnish, string main)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCorrectiveActionAsync(model.Entity);
                if (!string.IsNullOrEmpty(finnish))
                {
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                        return RedirectToAction("Edit", "Home", new {id = model.Entity.ProblemId});
                    return Redirect(model.ReturnUrl);
                }

                if (!string.IsNullOrEmpty(main))
                {
                    return RedirectToAction("Create", "CorrectiveActions", new {id = model.Entity.ProblemId});
                }
            }

            return View(model);

            // Check for any validation errors
            // if (ModelState.IsValid)
            // {
            //     var x = await _service.AddCorrectiveActionAsync(model.Action);
            //     var pp = JsonConvert.SerializeObject(x, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver(), ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            //     var p = Json(pp);
            //     return p;
            // }
            // return View(model);
        }

        #endregion

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
            var entity = await _service.GetCorrectiveActionAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        #endregion

        #region Edit 

        /// <summary>
        /// The method used to get the edit product view
        /// GET: Products/Home/Edit/{id}
        /// </summary>
        /// <param name="id">The id of the product to be updated</param>
        /// <returns>The edit product view with the relevant product</returns>
        public async Task<IActionResult> Edit(string id, string returnUrl)
        {
            // Check to see if id is populated
            if (id == null)
            {
                return NotFound();
            }

            // Finds the correct product category
            var entity = await _service.GetCorrectiveActionAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            var model = new CorrectiveActionAddEditViewModel()
            {
                ReturnUrl = returnUrl,
                Entity = entity,
                Cause = entity.Cause
            };

            return View(model);
        }

        /// <summary>
        /// Posts the edit view to the server
        /// </summary>
        /// <param name="model">The model that the enity is being updated from</param>
        /// <returns>The relevant view</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(CorrectiveActionAddEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var y = await _service.UpdateCorrectiveActionAsync(model.Entity);
                return Redirect(model.ReturnUrl);
            }
            return View(model);
        }

        #endregion

        #region Delete 

        public async Task<ActionResult> Delete(string id)
        {
            var entity = await _service.GetCorrectiveActionAsync(id);

            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete corrective action ? " +
                               $"<br/> with id {entity.Id}",
                ControllerUrl = "/Troubleshooting/CorrectiveActions/Delete",
                EntityId = entity.Id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _service.RemoveCorrectiveAction(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
    }
}