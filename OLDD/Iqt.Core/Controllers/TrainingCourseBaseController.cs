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
    public class TrainingCourseBaseController : Controller
    {
        protected readonly ITrainingCourseService Service;
        protected readonly IFileFactory FileFactory;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service">The injected category context service</param>
        public TrainingCourseBaseController(ITrainingCourseService service, IFileFactory fileFactory)
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
            var model = new TrainingCourseIndexModel(await list.ToListAsync(), size, page);

            // Return the view with the model
            return View(model);
        }

        /// <summary>
        /// Sets up a list view for the <see cref="TrainingCourse"/>
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
        /// Setup the details view with a specific <see cref="TrainingCourse"/>
        /// </summary>
        /// <param name="id">The id of the <see cref="TrainingCourse"/> that needs to be displayed</param>
        /// <returns>The <see cref="TrainingCourse"/> details view</returns>
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
            var model = new TrainingCourseDetailsModel(category)
            {
                Next = await Service.GetNextAsync(category),
                Previous = await Service.GetPreviousAsync(category)
            };

            // return the detail view with model
            return View(model);
        }

        #region Create        

        /// <summary>
        /// Gets the view and model for creating a new <see cref="TrainingCourse"/>
        /// </summary>
        /// <returns>The create view and model</returns>
        public IActionResult Create()
        {
            // Setup the blog entry edit model
            var model = new TrainingCourseAddEditModel();

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
        public virtual async Task<IActionResult> Create(TrainingCourseAddEditModel model, string main, string finnish)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {

                if (!model.Entity.DoNotCreateDocumentsFolder)
                {
                    FileFactory.CreateDirectory(Path.Combine("wwwroot\\Courses", model.Entity.FullPath));
                }

                await Service.AddAsync(model);

                if (finnish != null)
                {
                    return RedirectToAction(nameof(List), "Home");
                }
                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Home", new { id = model.Entity.Id });
                }
            }

            // Returns the view with the model
            return View(model);
        }

        #endregion

        #region Edit

        /// <summary>
        /// The method used to get the edit <see cref="TrainingCourse"/> view
        /// GET: TrainingCourses/Home/Edit/{id}
        /// </summary>
        /// <param name="id">The id of the <see cref="TrainingCourse"/> to be updated</param>
        /// <returns>The edit product view with the relevant product</returns>
        public virtual async Task<IActionResult> Edit(string id)
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

            var model = new TrainingCourseAddEditModel(category);

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
        public virtual async Task<IActionResult> Edit(TrainingCourseAddEditModel model, string main, string finnish, string sub)
        {
            // Check for any validation errors
              if (ModelState.IsValid)
            {
                await Service.UpdateAsync(model);

                if (finnish != null)
                {
                    return RedirectToAction(nameof(List), "Home");
                }
                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Home", new { id = model.Entity.Id });
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

        public ActionResult Delete(string id)
        {
            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete this Training Course ",
                ControllerUrl = Url.Action("Delete", new { id }),
                EntityId = id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var trainingCourse = await Service.GetAsync(id);
            var path = Path.Combine("wwwroot\\Courses", trainingCourse.FileFolder);
            if (Directory.Exists(path))
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                directory.Delete(true);
            }

            await Service.DeleteAsync(id);
            var y = Json(true);
            return y;
        }

        #endregion

        /// <summary>
        /// The method to setup the create view
        /// </summary>
        /// <param name="parentId">The identity of the question this answer belongs to</param>
        /// <returns>The create view</returns>
        public IActionResult CreateAssessmentElement(string parentId)
        {
            var question = Service.GetAsync(parentId);
            if (question == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this problem before adding any question or corrective actions",
                    ControllerUrl = "/TrainingCourses/Home/CreateAssessmentElement",
                    EntityId = parentId
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }

            // Create new answer
            var model = new AssessmentElement<TrainingCourse>()
            {
                Id = Guid.NewGuid().ToString(),
                EntityId = parentId
            };
            // Return the view
            return PartialView("_CreateCourseAssessmentElement", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssessmentElement(AssessmentElement<TrainingCourse> model)
        {
            await Service.AddAssessmentElementAsync<TrainingCourse>(model);
            return RedirectToAction("Edit", "Home", new {area="TrainingCourses", id = model.EntityId });
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
                ControllerUrl = "/TrainingCourses/Home/DeleteAssessmentElement",
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
            await Service.RemoveCourseAssessmentElementAsync(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion

        public ActionResult DeleteStudentCourse(string studentId, string courseId)
        {
            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete this Student Course ",
                ControllerUrl = Url.Action("Delete", new { studentId = studentId, courseId = courseId }),
                EntityId = studentId
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        [HttpPost, ActionName("DeleteStudentCourse")]
        public async Task<ActionResult> DeleteStudentCourseConfirmed(string studentId, string courseId)
        {
            await Service.DeleteStudentCourseAsync(studentId, courseId);
            var y = Json(true);
            return y;
        }

    }
}