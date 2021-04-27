using System;
using System.Threading.Tasks;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;
using Troubleshooting.Core.Context.Services;

// ReSharper disable Mvc.ViewNotResolved
// ReSharper disable Mvc.PartialViewNotResolved

namespace Troubleshooting.Core.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The frequently asked questions base controller
    /// </summary>
    [Area("Faqs")]
    public class AnswerBaseController : Controller
    {
        /// <summary>
        /// The Blog Context Service for this controller
        /// </summary>
        private readonly FaqContext _service;

        /// <summary>
        /// The default constructor with injected parameters
        /// </summary>
        /// <param name="service">The context service for this controller</param>
        public AnswerBaseController(FaqContext service)
        {
            _service = service;
        }

        #region Create

        /// <summary>
        /// The method to setup the create view
        /// </summary>
        /// <param name="parentId">The identity of the question this answer belongs to</param>
        /// <returns>The create view</returns>
        public async Task<IActionResult> Create(string parentId)
        {
            var question = await _service.GetAsync(parentId);
            if (question == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this problem before adding any question or corrective actions",
                    ControllerUrl = "/Troubleshooting/Causes/Delete",
                    EntityId = parentId
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }

            // Create new answer
            var model = new Answer()
            {
                Id = Guid.NewGuid().ToString(),
                QuestionId = parentId
            };
            // Return the view
            return PartialView("_Create",model);
        }

        /// <summary>
        /// The method to post the new faq answer to the server
        /// </summary>
        /// <param name="faqAnswer">the answer to post to the server</param>
        /// <returns>The index view if successful otherwise the same view with errors</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Answer faqAnswer)
        {
            // Check for validation errors
            if (ModelState.IsValid)
            {
                await _service.AddAnswer(faqAnswer);
                var p = Json(new { id = faqAnswer.Id, answer = faqAnswer.AnswerString });
                return p;
            }
            return View(faqAnswer);
        }

        #endregion

        #region Edit

        /// <summary>
        /// The method to setup the edit view
        /// </summary>
        /// <param name="id">The identity of the answer</param>
        /// <returns>The edit view</returns>
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqAnswer = await _service.GetAnswer(id);

            if (faqAnswer == null)
            {
                return NotFound();
            }
            return PartialView("_Edit",faqAnswer);
        }

        /// <summary>
        /// The method used to post the updated Faq Answer
        /// </summary>
        /// <param name="faqAnswer">The model that the answer should be updated to</param>
        /// <returns>The index view if update was successful otherwise the same view and model</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(Answer faqAnswer)
        {
            // Check for validation errors
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAnswer(faqAnswer);

                    var p = Json(new {id = faqAnswer.Id, answer = faqAnswer.AnswerString});
                    return p;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            // Return the current model and view if any errors
            return View(faqAnswer);
        }

        #endregion

        #region Delete 

        /// <summary>
        /// Gets the delete modal and displays it
        /// </summary>
        /// <param name="id">The id of the answer to be deleted</param>
        /// <returns>The delete modal and model</returns>
        public async Task<ActionResult> Delete(string id)
        {
            var entity = await _service.GetAnswer(id);

            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete answer ? " +
                               $"<br/> with id {entity.Id}",
                ControllerUrl = "/Faqs/Answers/Delete",
                EntityId = entity.Id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// Posts the delete mehtod to the server
        /// </summary>
        /// <param name="id">The id of the answer to be deleted</param>
        /// <returns>The entity that was deleted in JSON</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var answer = await _service.GetAnswer(id);

            await _service.DeleteAnswer(answer);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
    }
}