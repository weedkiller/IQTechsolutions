using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    public class TrainingSectionBaseController : Controller
    {
        protected readonly ITrainingSectionService Service;
        protected readonly IFileFactory FileFactory;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service">The injected category context service</param>
        public TrainingSectionBaseController(ITrainingSectionService service, IFileFactory fileFactory)
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
            var model = new TrainingSectionIndexModel(await list.ToListAsync(), size, page);

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
            var model = new TrainingSectionDetailsModel(category)
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
            var model = new TrainingSectionAddEditModel()
            {
                Entity = new TrainingSection(),
                ParentId = parentId
            };
            if (!string.IsNullOrEmpty(parentId))
            {
                var trainingModule = await Service.GetParentAsync(parentId);

                model.Entity.TrainingModule = trainingModule;
                model.Entity.TrainingModuleId = trainingModule.Id;
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
        /// POST: TrainingCourses/Home/Create
        /// </summary>
        /// <param name="model">the model of the post that should be added</param>
        /// <param name="finnish">The finnish button value</param>
        /// <param name="main">The main submit button value</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TrainingSectionAddEditModel model, string main, string finnish)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                if (model.Entity.TrainingModuleId != null)
                {
                    var parentModule = await Service.GetParentAsync(model.Entity.TrainingModuleId);

                    if (!string.IsNullOrEmpty(parentModule.FileFolder))
                    {
                        if (!model.DoNotCreateDocumentsFolder)
                        {
                            FileFactory.CreateDirectory(Path.Combine("wwwroot\\Courses", model.Entity.FullPath));
                        }
                    }
                }

                await Service.AddAsync(model);
                
                if (finnish != null)
                {
                    if (string.IsNullOrEmpty(model.Entity.TrainingModuleId))
                    {
                        return RedirectToAction(nameof(Edit), "Sections", new { id = model.Entity.ParentSectionId });
                    }
                    return RedirectToAction(nameof(Edit), "Modules", new { id = model.Entity.TrainingModuleId });
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
        /// GET: TrainingCourses/Home/Edit/{id}
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

            var model = new TrainingSectionAddEditModel()
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
        public virtual async Task<IActionResult> Edit(TrainingSectionAddEditModel model, string main, string finnish, string sub)
        {
            // Check for any validation errors
              if (ModelState.IsValid)
            {
                await Service.UpdateAsync(model);

                if (finnish != null)
                {
                    return RedirectToAction(nameof(Edit), "Modules", new { id = model.Entity.TrainingModuleId });
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

        public async Task<ActionResult> DeleteConfirmed(TrainingSection model)
        {
            await Service.DeleteAsync(model.Id);
            if (model.TrainingModuleId != null)
            {
                var trainingSection = await Service.GetAsync(model.Id);
                var path = Path.Combine("wwwroot\\Courses", trainingSection.FullPath);
                if (Directory.Exists(path))
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    directory.Delete(true);
                }
                return RedirectToAction(nameof(Edit), "Modules", new { id = model.TrainingModuleId });
            }
            return RedirectToAction(nameof(Edit), "Sections", new { id = model.ParentSectionId });
        }

        #endregion

    }
}