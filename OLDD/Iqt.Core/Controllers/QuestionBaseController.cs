using System.Linq;
using System.Threading.Tasks;
using Iqt.Base.Models;
using Iqt.Troubleshooting.Data;
using Iqt.Troubleshooting.Entities;
using Iqt.Troubleshooting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ReSharper disable Mvc.ActionNotResolved
// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.PartialViewNotResolved

// ReSharper disable Mvc.ViewNotResolved
// ReSharper disable Mvc.AreaNotResolved

namespace Iqt.Troubleshooting.Controllers
{
    [Area("Faqs")]
    public class QuestionBaseController : Controller
    {
        /// <summary>
        /// The Context Service for this controller
        /// </summary>
        protected readonly FaqContext Service;

        /// <summary>
        /// The default constructor with injected parameters
        /// </summary>
        /// <param name="service">The context service for this controller</param>
        public QuestionBaseController(FaqContext service)
        {
            Service = service;
        }

        /// <summary>
        /// The method to setup the index view
        /// </summary>
        /// <returns>The index view</returns>
        [AllowAnonymous]
        public virtual async Task<IActionResult> Index()
        {
            var collection = await Service.GetAll().OrderBy(c => c.Created).ToListAsync();

            var model = new FaqIndexModel(collection)
            {
                Categories = Service.GetCategories().ToList()
            };

            return View(model);
        }

        /// <summary>
        /// The method to setup the list view
        /// </summary>
        /// <returns>The list view</returns>
        public async Task<IActionResult> List()
        {
            var collection = await Service.GetAll().OrderBy(c => c.Created).ToListAsync();

            var model = new FaqIndexModel(collection)
            {
                Categories = Service.GetCategories().ToList()
            };

            return View(model);
        }

        /// <summary>
        /// The method to setup the details view
        /// </summary>
        /// <param name="id">The identity ot the faq Question</param>
        /// <returns>The details view</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            // Check that the id populated
            if (id == null)
            {
                return NotFound();
            }

            // Get the question
            var faqQuestion = await Service.GetAsync(id);

            // Check if the question exist
            if (faqQuestion == null)
            {
                return NotFound();
            }

            // Return the details view
            return View(faqQuestion);
        }

        #region Create

        /// <summary>
        /// The method to setup the create view
        /// </summary>
        /// <returns>The create view</returns>
        public IActionResult Create()
        {
            // Get the available categories
            var availableCategories = Service.GetCategories().OrderBy(c => c.Name).ToList();
            var model = new FaqAddEditModel(new Question(), availableCategories);

            return View(model);
        }

        /// <summary>
        /// The method to post the newly created question to the server
        /// </summary>
        /// <param name="faqQuestion">the model of the newly created question</param>
        /// <param name="main">the main submit button value</param>
        /// <param name="ans">The create answer button value</param>
        /// <param name="finnish">The button pressed when modal is finished</param>
        /// <returns>The index view if successful, otherwise the same view and model</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FaqAddEditModel faqQuestion, string main, string ans, string finnish)
        {
            // Check for validation errors
            if (ModelState.IsValid)
            {
                await Service.AddAsync(faqQuestion);

                if (finnish != null)
                {
                    // Return the index view
                    return RedirectToAction(nameof(List));
                }
                // if the main submit button is clicked
                if (main != null)
                {
                    // Return the index view
                    return RedirectToAction(nameof(Edit), "Home", new{id=faqQuestion.Entity.Id});
                }
                // if the create answer submit button is clicked
                if (ans != null)
                {
                    // Return the Create answer view
                    return RedirectToAction(nameof(Create), "Answers", new { area = "Faqs", id = faqQuestion.Entity.Id });
                }
            }
            return View(faqQuestion);
        }

        #endregion

        #region Edit

        /// <summary>
        /// The method used to get the edit product view
        /// </summary>
        /// <param name="id">The id of the question to be updated</param>
        /// <returns>The edit view</returns>
        public async Task<IActionResult> Edit(string id)
        {
            // Check if the identity field is populated
            if (id == null)
            {
                return NotFound();
            }

            // Get the correct question
            var faqQuestion = await Service.GetAsync(id);

            // Get the available categories
            var availableCategories = Service.GetCategories().OrderBy(c => c.Name).ToList();

            // Check to see if the question exist
            if (faqQuestion == null)
            {
                return NotFound();
            }

            var model = new FaqAddEditModel(faqQuestion, availableCategories);
            
            return View(model);
        }

        /// <summary>
        /// The method used to post to the update post to the server
        /// </summary>
        /// <param name="ans">The create answer button value</param>
        /// <param name="faqQuestion">The model the question should be update to </param>
        /// <param name="main">The main submit button value</param>
        /// /// <param name="finnish">The button pressed when modal is finished</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FaqAddEditModel faqQuestion, string main, string ans, string finnish)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(faqQuestion);

                // if the main submit button is clicked
                if (main != null)
                {
                    // Return the index view
                    return RedirectToAction(nameof(Edit), "Home", new { id = faqQuestion.Entity.Id });
                }
                // if the create answer submit button is clicked
                if (ans != null)
                {
                    // Return the Create answer view
                    return RedirectToAction(nameof(Create), "Answers", new { area = "Faqs", id = faqQuestion.Entity.Id });
                }
                return RedirectToAction(nameof(List));
            }
            return View(faqQuestion);
        }

        #endregion

        #region Delete

        /// <summary>
        /// The method used to setup the Delete Page
        /// </summary>
        /// <param name="id">The identity of the question that should be deleted</param>
        /// <returns>The delete page</returns>
        public async Task<IActionResult> Delete(string id)
        {
            var entity = await Service.GetAsync(id);

            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete answer ? " +
                               $"<br/> with id {entity.Id}",
                ControllerUrl = "/Faqs/Home/Delete",
                EntityId = entity.Id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// The method that removes the selected product from the database
        /// </summary>
        /// <param name="id">The id of the product that should be deleted</param>
        /// <returns> The index view after deletion was successful</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await Service.DeleteAsync(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
    }
}
