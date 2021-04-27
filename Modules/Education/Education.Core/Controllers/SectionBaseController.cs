using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Education.Base.Entities;
using Education.Core.Context.Services;
using Education.Core.Models;
using Filing.Core.Factories;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ReSharper disable Mvc.PartialViewNotResolved
// ReSharper disable Mvc.ActionNotResolved
// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.ViewNotResolved

namespace Education.Core.Controllers
{
    public class SectionBaseController : Controller
    {
        protected readonly SectionContext Service;
        protected readonly IFileFactory FileFactory;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service">The injected category context service</param>
        public SectionBaseController(SectionContext service, IFileFactory fileFactory)
        {
            Service = service;
            FileFactory = fileFactory;
        }

        /// <summary>
        /// Set up the index model and view
        /// </summary>
        /// <param name="size">The amount of items on the page</param>
        /// <param name="page">The page number</param>
        /// <returns>the index view</returns>
        [AllowAnonymous]
        public virtual async Task<IActionResult> Index(int? size, int? page)
        {
            // Get the correct entry
            var list = Service.GetAll();

            // Set up the model for the index page
            var model = new SectionIndexModel(await list.ToListAsync(), size, page);

            // Return the view with the model
            return View(model);
        }

        /// <summary>
        /// Sets up a list view for the <see cref="TrainingSection"/>
        /// </summary>
        /// <returns>the index list view</returns>
        public async Task<IActionResult> List()
        {
            // Get a list of the entries
            var model = await Service.GetAll().OrderByDescending(c => c.Created).ToListAsync();
            // Returns the list view and the model
            return View(model);
        }

        /// <summary>
        /// Setup the details view with a specific <see cref="TrainingSection"/>
        /// </summary>
        /// <param name="id">The id of the <see cref="TrainingSection"/> that needs to be displayed</param>
        /// <returns>The <see cref="TrainingSection"/> details view</returns>
        [AllowAnonymous]
        public virtual async Task<IActionResult> Details(string id)
        {
            // Test to see if the id field is populated
            if (id == null)
            {
                return NotFound();
            }

            // Get the specific blog entry
            var category = await Service.GetAsync(id);

            // Setup the blog entry details page model
            var model = new SectionDetailsModel(category)
            {
                Next = await Service.GetNextAsync(category),
                Previous = await Service.GetPreviousAsync(category)
            };

            // return the detail view with model
            return View(model);
        }

        #region Create        

        /// <summary>
        /// Gets the view and model for creating a new <see cref="TrainingSection"/>
        /// </summary>
        /// <returns>The create view and model</returns>
        public async Task<IActionResult> Create(string parentId, string parentSectionId)
        {
            var model = new SectionAddEditModel()
            {
                Entity = new Section(),
                ParentId = parentId
            };
            if (!string.IsNullOrEmpty(parentId))
            {
                var trainingModule = await Service.GetParentAsync(parentId);

                model.Entity.Module = trainingModule;
                model.Entity.ModuleId = trainingModule.Id;
                model.Entity.FolderPath = trainingModule.FullPath;
            }
            else if (!string.IsNullOrEmpty(parentSectionId))
            {
                var parentSection = await Service.GetAsync(parentSectionId);

                model.Entity.ParentSection = parentSection;
                model.Entity.ParentSectionId = parentSection.Id;
                model.Entity.FolderPath = parentSection.FolderPath;
                model.Entity.FileFolder = parentSection.FileFolder;
            }

            // Setup the blog entry edit model
            

            // returns the create view with model
            return View(model);
        }

        /// <summary>
        /// The method used to post to the create post to the server
        /// POST: Courses/Home/Create
        /// </summary>
        /// <param name="model">the model of the post that should be added</param>
        /// <param name="finnish">The finnish button value</param>
        /// <param name="main">The main submit button value</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(SectionAddEditModel model, string main, string finnish)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                if (model.Entity.ModuleId != null)
                {
                    var parentModule = await Service.GetParentAsync(model.Entity.ModuleId);

                    if (!string.IsNullOrEmpty(parentModule.FileFolder))
                    {
                        if (!model.DoNotCreateDocumentsFolder)
                        {
                            FileFactory.CreateDirectory(Path.Combine("wwwroot\\Courses\\Modules\\Sections", model.Entity.FullPath));
                            model.Entity.FolderPath = "Courses\\Modules\\Sections";
                        }
                    }
                }

                await Service.AddAsync(model);
                
                if (finnish != null)
                {
                    if (string.IsNullOrEmpty(model.Entity.ModuleId))
                    {
                        return RedirectToAction(nameof(Edit), "Sections", new { id = model.Entity.ParentSectionId });
                    }
                    return RedirectToAction(nameof(Edit), "Modules", new { id = model.Entity.ModuleId });
                }
                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Sections", new { id = model.Entity.Id });
                }
            }

            // Returns the view with the model
            return View(model);
        }

        #endregion

        #region Edit

        /// <summary>
        /// The method used to get the edit <see cref="TrainingSection"/> view
        /// GET: Courses/Home/Edit/{id}
        /// </summary>
        /// <param name="id">The id of the <see cref="TrainingSection"/> to be updated</param>
        /// <returns>The edit product view with the relevant product</returns>
        public async Task<IActionResult> Edit(string id)
        {
            // Check to see if id is populated
            if (id == null)
            {
                return NotFound();
            }

            var category = await Service.GetAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var model = new SectionAddEditModel()
            {
                Entity = category
            };

            return View(model);
        }

        /// <summary>
        /// The method used to post to the update post to the server
        /// POST: Courses/Home/Edit/{id}
        /// </summary>
        /// <param name="model">The model that the post is being updated from</param>
        /// <param name="main">The main submit button</param>
        /// <param name="finnish">The finnish submit button value</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(SectionAddEditModel model, string main, string finnish, string sub)
        {
            // Check for any validation errors
              if (ModelState.IsValid)
            {
                await Service.UpdateAsync(model);

                if (finnish != null)
                {
                    return RedirectToAction(nameof(Edit), "Modules", new { id = model.Entity.ModuleId });
                }
                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Sections", new { id = model.Entity.Id });
                }
                if (sub != null)
                {
                    return RedirectToAction(nameof(Create), "Sections", new { parentId = model.Entity.Id });
                }
            }
            return View(model);
        }

        #endregion

        #region Delete 

        public async Task<ActionResult> Delete(string id)
        {
            var trainingSection = await Service.GetAsync(id);

            return PartialView("_Delete", trainingSection);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<ActionResult> DeleteConfirmed(Section model)
        {
            await Service.DeleteAsync(model.Id);
            if (model.ModuleId != null)
            {
                var trainingSection = await Service.GetAsync(model.Id);
                var path = Path.Combine("wwwroot\\Courses", trainingSection.FullPath);
                if (Directory.Exists(path))
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    directory.Delete(true);
                }
                return RedirectToAction(nameof(Edit), "Modules", new { id = model.ModuleId });
            }
            return RedirectToAction(nameof(Edit), "Sections", new { id = model.ParentSectionId });
        }

        #endregion

        #region Assessment Eleement 

        /// <summary>
        /// The method to setup the create view
        /// </summary>
        /// <param name="parentId">The identity of the question this answer belongs to</param>
        /// <returns>The create view</returns>
        public async Task<IActionResult> CreateAssessmentElement(string parentId)
        {
            var question = Service.GetAsync(parentId);
            if (question == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this problem before adding any question or corrective actions",
                    ControllerUrl = "/Courses/Sections/CreateAssessmentElement",
                    EntityId = parentId
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }

            // Create new answer
            var model = new AssessmentElement<Module>()
            {
                Id = Guid.NewGuid().ToString(),
                EntityId = parentId
            };
            // Return the view
            return PartialView("_CreateSectionAssessmentElement", model);
        }

        /// <summary>
        /// Confirms the removal of a module <see cref="AssessmentElement{T}"/> from the database
        /// </summary>
        /// <param name="model">The <see cref="AssessmentElement{T}"/> model</param>
        /// <returns>Redirects to the appropriate page</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAssessmentElement(AssessmentElement<Section> model)
        {
            await Service.AddAssessmentElementAsync(model);
            return RedirectToAction("Edit", "Sections", new { area = "Courses", id = model.EntityId });
        }

        /// <summary>
        /// Gets the edit specific <see cref="AssessmentElement{T}"/> view
        /// </summary>
        /// <param name="id">The <see cref="AssessmentElement{T}"/> identity</param>
        /// <returns>The edit <see cref="AssessmentElement{T}"/> partial view for a model</returns>
        [HttpGet]
        public async Task<IActionResult> EditAssessmentElement(string id)
        {
            var module = await Service.GetSpecificAssessmentElementAsync(id);// Return the view
            return PartialView("_EditSectionAssessmentElement", module);
        }

        [HttpPost]
        public async Task<IActionResult> EditAssessmentElement(AssessmentElement<Section> model)
        {
            await Service.EditAssessmentElementAsync(model);
            return Json(model);
        }

        /// <summary>
        /// The default delete view
        /// GET: Employees/Home/Delete/{Id}
        /// </summary>
        /// <param name="id">The identity of the employee to be deleted</param>
        /// <returns>The default delete view</returns>
        public async Task<IActionResult> DeleteAssessmentElement(string id)
        {
            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete this assessment item ? ",
                ControllerUrl = "/Courses/Sections/DeleteAssessmentElement",
                EntityId = id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// Post to delete the employee from the database
        /// </summary>
        /// <param name="id">The identity of the employee to be deleted</param>
        /// <returns>A json bool result to indicate whether the removal was succesful</returns>
        [HttpPost, ActionName("DeleteAssessmentElement")]
        public async Task<IActionResult> DeleteAssessmentElementConfirmed(string id)
        {
            await Service.RemoveAssessmentElementAsync(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion

        #region Assessment Element Answers

        /// <summary>
        /// View all the answers associated with a specific <see cref="AssessmentElement{T}"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="MultipleChoiceAnswer{T}"/></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ViewSectionsAssessmentElementAnswers(string parentId)
        {
            var assessment = await Service.GetSpecificAssessmentElementAsync(parentId);
            var model = new SectionAssessmentElementAnswerListModel()
            {
                ModuleId = assessment.EntityId,
                AssessmentElementId = parentId,
                Answers = assessment.Answers
            };
            // Return the view
            return PartialView("_ViewSectionAssessmentAnswers", model);
        }

        /// <summary>
        /// Gets the partial view for creating assessment element <see cref="MultipleChoiceAnswer{T}"/> answers
        /// </summary>
        /// <returns>The partial view that contains the create assessment element answer modal</returns>
        [HttpGet]
        public async Task<IActionResult> CreateSectionsAssessmentElementAnswer(string parentId)
        {
            var assessment = await Service.GetSpecificAssessmentElementAsync(parentId);
            var model = new SectionAssessmentElementAnswerUpdateModel()
            {
                SectionId = assessment.EntityId,
                AssessmentElementId = parentId,
                AssessmentElementAnswerId = Guid.NewGuid().ToString()
            };
            // Return the view
            return PartialView("_CreateSectionAssessmentAnswers", model);
        }

        /// <summary>
        /// Posts the modal to the server containing the assessment element answer that was created
        /// </summary>
        /// <param name="model">The model of the assessment element answer that was created</param>
        /// <returns>Redirects to the relevant view</returns>
        [HttpPost]
        public async Task<IActionResult> CreateSectionsAssessmentElementAnswer(SectionAssessmentElementAnswerUpdateModel model)
        {
            var assessmentAnswer = new MultipleChoiceAnswer<Module>()
            {
                Id = model.AssessmentElementAnswerId,
                AssessmentElementId = model.AssessmentElementId,
                Answer = model.Answer,
                IsCorrect = model.IsCorrect
            };
            return RedirectToAction("Edit", "Sections", new { area = "Courses", id = model.SectionId });
        }

        /// <summary>
        /// Gets the Assessment element answer edit partial view for a modal
        /// </summary>
        /// <param name="id">The identity of the assessment element answer that needs to be removed</param>
        /// <returns>The edit partial view</returns>
        [HttpGet]
        public async Task<IActionResult> EditSectionsAssessmentElementAnswer(string id)
        {
            var module = await Service.GetAssessmentAnswerAsync(id);
            var model = new ModuleAssessmentElementAnswerUpdateModel()
            {
                AssessmentElementId = module.AssessmentElementId,
                AssessmentElementAnswerId = module.Id,
                Answer = module.Answer,
                IsCorrect = module.IsCorrect
            };
            // Return the view
            return PartialView("_EditSectionsAssessmentAnswers", model);
        }

        /// <summary>
        /// Posts the update <see cref="MultipleChoiceAnswer{T}"/> results to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Redirects to the appropriate page</returns>
        [HttpPost]
        public async Task<IActionResult> EditSectionAssessmentElementAnswer(AssessmentElement<Module> model)
        {
            return RedirectToAction("Edit", "Sections", new { area = "Courses", id = model.Entity.Id });
        }

        /// <summary>
        /// The default delete view
        /// </summary>
        /// <param name="id">The identity of the <see cref="MultipleChoiceAnswer{T}"/> to be deleted</param>
        /// <returns>The default delete view</returns>
        public async Task<IActionResult> DeleteAssessmentElementAnswer(string id)
        {
            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete this assessment item ? ",
                ControllerUrl = "/Courses/Sections/DeleteAssessmentElement",
                EntityId = id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// Post to delete the <see cref="MultipleChoiceAnswer{T}"/> from the database
        /// </summary>
        /// <param name="id">The identity of the <see cref="MultipleChoiceAnswer{T}"/> to be deleted</param>
        /// <returns>A json bool result to indicate whether the removal was successful</returns>
        [HttpPost, ActionName("DeleteAssessmentElementAnswer")]
        public async Task<IActionResult> DeleteAssessmentElementAnswerConfirmed(string id)
        {
            await Service.RemoveAssessmentAnswerAsync(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
    }
}