using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Iqt.Base.Models;
using Iqt.Filing.Interfaces;
using Iqt.Training.Entities;
using Iqt.Training.Interfaces;
using Iqt.Training.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ReSharper disable Mvc.PartialViewNotResolved
// ReSharper disable Mvc.ActionNotResolved
// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.ViewNotResolved

namespace Iqt.Core.Controllers
{
    public class TrainingModuleBaseController : Controller
    {
        protected readonly ITrainingModuleService Service;
        protected readonly IFileFactory FileFactory; 

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service">The injected category context service</param>
        public TrainingModuleBaseController(ITrainingModuleService service, IFileFactory fileFactory)
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
            var model = new TrainingModuleIndexModel(list.ToList(), size, page);

            // Return the view with the model
            return View(model);
        }

        /// <summary>
        /// Sets up a list view for the <see cref="TrainingModule"/>
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
        /// Setup the details view with a specific <see cref="TrainingModule"/>
        /// </summary>
        /// <param name="id">The id of the <see cref="TrainingModule"/> that needs to be displayed</param>
        /// <returns>The <see cref="TrainingModule"/> details view</returns>
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
            var model = new TrainingModuleDetailsModel(category)
            {
                Next = await Service.GetNextAsync(category),
                Previous = await Service.GetPreviousAsync(category)
            };

            // return the detail view with model
            return View(model);
        }

        #region Create        

        /// <summary>
        /// Gets the view and model for creating a new <see cref="TrainingModule"/>
        /// </summary>
        /// <returns>The create view and model</returns>
        public async Task<IActionResult> Create(string parentId)
        {
            var trainingCourse = await Service.GetParentAsync(parentId);

            // Setup the blog entry edit model
            var model = new TrainingModuleAddEditModel()
            {
                Entity = new TrainingModule()
                {
                    FolderPath = trainingCourse.FullPath,
                    TrainingCourse = trainingCourse,
                    TrainingCourseId = trainingCourse.Id
                },
                ParentId = parentId
            };

            // returns the create view with model
            return View(model);
        }

        /// <summary>
        /// The method used to post to the create post to the server
        /// POST: TrainingCourses/Home/Create
        /// </summary>
        /// <param name="model">the model of the post that should be added</param>
        /// <param name="finnish">The finnish button value</param>
        /// <param name="main">The main submit button value</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TrainingModuleAddEditModel model, string main, string finnish)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                var parentSection = await Service.GetParentAsync(model.Entity.TrainingCourseId);

                if (!string.IsNullOrEmpty(parentSection.FileFolder))
                {
                    if (!model.DoNotCreateDocumentsFolder)
                    {
                        FileFactory.CreateDirectory(Path.Combine("wwwroot\\Courses", model.Entity.FullPath));
                    }
                }

                await Service.AddAsync(model);
                
                if (finnish != null)
                {
                    return RedirectToAction(nameof(List), "Home", new { id = model.Entity.TrainingCourseId });
                }
                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Modules", new { id = model.Entity.Id });
                }
            }

            // Returns the view with the model
            return View(model);
        }

        #endregion

        #region Edit

        /// <summary>
        /// The method used to get the edit <see cref="TrainingModule"/> view
        /// GET: TrainingCourses/Home/Edit/{id}
        /// </summary>
        /// <param name="id">The id of the <see cref="TrainingModule"/> to be updated</param>
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

            var model = new TrainingModuleAddEditModel()
            {
                Entity = category
            };

            return View(model);
        }

        /// <summary>
        /// The method used to post to the update post to the server
        /// POST: TrainingCourses/Home/Edit/{id}
        /// </summary>
        /// <param name="model">The model that the post is being updated from</param>
        /// <param name="main">The main submit button</param>
        /// <param name="finnish">The finnish submit button value</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(TrainingModuleAddEditModel model, string main, string finnish, string sub)
        {
            // Check for any validation errors
              if (ModelState.IsValid)
            {
                await Service.UpdateAsync(model);

                if (finnish != null)
                {
                    return RedirectToAction(nameof(Edit), "Home", new { id = model.Entity.TrainingCourseId });
                }
                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Modules", new { id = model.Entity.Id });
                }
                if (sub != null)
                {
                    return RedirectToAction(nameof(Create), "Modules", new { parentId = model.Entity.Id });
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

        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var trainingSection = await Service.GetAsync(id);
            var path = Path.Combine("wwwroot\\Courses", trainingSection.FullPath);
            if (Directory.Exists(path))
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                directory.Delete(true);
            }

            await Service.DeleteAsync(id);
            return RedirectToAction(nameof(Edit), "Home", new { id = trainingSection.TrainingCourseId });
        }

        #endregion

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
                    ControllerUrl = "/TrainingCourses/Modules/CreateAssessmentElement",
                    EntityId = parentId
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }

            // Create new answer
            var model = new AssessmentElement<TrainingModule>()
            {
                Id = Guid.NewGuid().ToString(),
                EntityId = parentId
            };
            // Return the view
            return PartialView("_CreateModuleAssessmentElement", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssessmentElement(AssessmentElement<TrainingModule> model)
        {
            await Service.AddAssessmentElementAsync(model);
            return RedirectToAction("Edit", "Home", new { area = "TrainingCourses", id = model.EntityId });
        }

        #region Delete 
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
                ControllerUrl = "/TrainingCourses/Modules/DeleteAssessmentElement",
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

    }
}