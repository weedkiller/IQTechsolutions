using System;
using System.Threading.Tasks;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Troubleshooting.Data;
using Iqt.Troubleshooting.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CorrectiveActionAddEditViewModel = Iqt.Troubleshooting.Models.CorrectiveActionAddEditViewModel;

// ReSharper disable Mvc.PartialViewNotResolved

// ReSharper disable Mvc.ViewNotResolved
// ReSharper disable Mvc.ActionNotResolved

namespace Iqt.Troubleshooting.Controllers
{
    [Area("Troubleshooting")]
    public class CorrectiveActionsBaseController : Controller
    {
        /// <summary>
        /// The Repository manger for this controller
        /// </summary>
        private readonly ProblemsContext _service;
        protected IRepositoryManager Manager;

        #region Constructors

        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected application repository manager</param>
        public CorrectiveActionsBaseController(ProblemsContext service)
        {
            _service = service;
        }

        #endregion

        #region Create Product

        /// <summary>
        /// Gets the create view and model
        /// </summary>
        /// <returns>The create view</returns>
        public IActionResult Create(string problemId, string causeId)
        {
            var cause = Manager.Repository<Cause>().GetEntity(causeId);
            var problem = Manager.Repository<Problem>().GetEntity(problemId);
            var model = new CorrectiveActionAddEditViewModel
            {
                Entity = new CorrectiveAction()
                {
                    CauseId = causeId
                },
                Cause = cause,
                Problem = problem
            };
            return PartialView("_Create", model);
        }

        /// <summary>
        /// Posts the add model to the server
        /// </summary>
        /// <param name="model">the model of the entity that should be added</param>
        /// <returns>The relevant view and model</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CorrectiveActionAddEditViewModel model)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                var x = await _service.AddCorrectiveActionAsync(model.Entity);
                var pp = JsonConvert.SerializeObject(x, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver(), ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var p = Json(pp);
                return p;
            }
            return PartialView("_Create", model);
        }

        #endregion

        #region Edit 

        /// <summary>
        /// The method used to get the edit product view
        /// GET: Products/Home/Edit/{id}
        /// </summary>
        /// <param name="id">The id of the product to be updated</param>
        /// <returns>The edit product view with the relevant product</returns>
        public async Task<IActionResult> Edit(string id)
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
                Entity = entity,
                Cause = entity.Cause
            };

            return PartialView("_Edit",model);
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

                try
                {
                    var pp = JsonConvert.SerializeObject(y, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver(), ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
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
        public ActionResult DeleteConfirmed(string id)
        {
            _service.RemoveCorrectiveAction(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
    }
}
