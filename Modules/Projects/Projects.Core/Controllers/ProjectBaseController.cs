using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grouping.Core.Context.Services;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projects.Base.Entities;
using Projects.Core.Context.Services;
using Projects.Core.Models;

// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.ActionNotResolved

// ReSharper disable Mvc.ViewNotResolved
// ReSharper disable Mvc.AreaNotResolved

namespace Projects.Core.Controllers
{
    public class ProjectBaseController : Controller
    {
        private readonly ProjectsContext _service;
        private readonly CategoryContext<Project> _categoryService;

        #region Constructor

        /// <summary>
        /// The default constructor with injected parameters
        /// </summary>
        /// <param name="service">The context service</param>
        public ProjectBaseController(ProjectsContext service, CategoryContext<Project> categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        #endregion

        #region Index

        /// <summary>
        /// Set up the index model and view
        /// </summary>
        /// <param name="size">The size fo the page</param>
        /// <param name="page">The page number</param>
        /// <returns>the index view</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Index(int? size, int? page, string categoryId, string tagId)
        {
            var projects = await _service.GetAll().OrderByDescending(c => c.Created).ToListAsync();

            if (!string.IsNullOrEmpty(categoryId))
            {
                var projectlist = from item in projects
                    from cat in item.Categories
                    where cat.CategoryId == categoryId
                    select item;

                projects = projectlist.ToList();
            }

            var model = new ProjectIndexModel(projects)
            {
                Categories = _service.GetCategories().OrderBy(c => c.Category.Name).ToList(),
                PageCount = page ?? 1,
                PageSize = size ?? 12
            };            

            // Return the view with the model
            return View(model);
        }

        /// <summary>
        /// Sets up a list view for the services
        /// </summary>
        /// <returns>the index list view</returns>
        public async Task<IActionResult> List()
        {
            // Get a list of the entries
            var model = await _service.GetAll().Where(c => c.ParentProjectId == null).ToListAsync();

            // Returns the list view and the model
            return View(model);
        }

        #endregion

        /// <summary>
        /// Setup the model/view with a specific service
        /// </summary>
        /// <param name="id">The id of the service that needs to be displayed</param>
        /// <returns>The service view and model</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            // Test to see if the id field is populated
            if (id == null)
            {
                return NotFound();
            }

            // Get a list of all blog entries
            var productList = _service.GetAll().Where(c => c.Featured).ToList();
            // Get the specific blog entry
            var product = await _service.GetAsync(id);

            // Setup the blog entry details page model
            var model = new ProjectDetailsPageModel(product)
            {
                Categories = _service.GetCategories(),
                FeaturedProjects = productList.OrderBy(c => c.Created).Where(c => c.Id != id),
                Tags = product.Tags,
                Previous = await _service.GetNextAsync(product),
                Next = await _service.GetNextAsync(product)
            };

            // return the detail view with model
            return View(model);
        }

       #region Create        

        /// <summary>
        /// Creates a new service
        /// </summary>
        /// <returns>The create view and model</returns>
        public IActionResult Create()
        {
            // Setup the blog entry edit model
            var model = new ProjectAddEditModel(new Project(), _categoryService.GetAllCategories().ToList());

            // returns the create view with model
            return View(model);
        }

        /// <summary>
        /// The method used to post to the created service to the server
        /// POST: Blog/Home/Create
        /// </summary>
        /// <param name="model">the model of the service that should be added</param>
        /// <param name="addFeature">The secondary submit button value</param>
        /// <param name="main">The main submit button value</param>
        /// <param name="finnish">The finnish button value</param>
        /// <returns>The create view and model</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectAddEditModel model, string addFeature, string main, string finnish)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                await _service.AddAsync(model);

                // if main submit button is clicked
                if (finnish != null)
                {
                    // return the entry list view
                    return RedirectToAction(nameof(List));
                }
                if (main != null)
                {
                    // return the entry list view
                    return RedirectToAction(nameof(Edit), "Home", new { area = "Projects", id = model.Entity.Id });
                }
            }

            // Returns the view with the model
            return View(model);
        }

        #endregion

        #region Edit

        /// <summary>
        /// The method used to get the edit service view
        /// </summary>
        /// <param name="id">The id of the service to be updated</param>
        /// <returns>The edit view and model</returns>
        public async Task<IActionResult> Edit(string id)
        {
            // Check to see if id is populated
            if (id == null)
            {
                return NotFound();
            }

            // Get the correct service entry
            var project = await _service.GetAll().FirstOrDefaultAsync(c => c.Id == id);

            // Check if the blogentry exist
            if (project == null)
            {
                return NotFound();
            }

            // Setup the new model for the page
            var model = new ProjectAddEditModel(project, _categoryService.GetAllCategories().ToList());

            return View(model);
        }

        /// <summary>
        /// The method used to post to the updated service to the server
        /// </summary>
        /// <param name="model">The model that the post is being updated from</param>
        /// <param name="addFeature">The add Comment button</param>
        /// <param name="main">The main submit button</param>
        /// <param name="finnish">The finnish button value</param>
        /// <returns>The List/Edit view</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ProjectAddEditModel model, string addFeature, string main, string finnish)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                var service = await _service.UpdateAsync(model);

                // if main submit button is clicked
                if (finnish != null)
                {
                    // return the entry list view
                    return RedirectToAction(nameof(List));
                }
                if (main != null)
                {
                    // return the entry list view
                    return RedirectToAction(nameof(Edit), "Home", new { area = "Projects", id = model.Entity.Id });
                }

            }

           return View(model);
        }

        #endregion

        #region Delete

        /// <summary>
        /// The method used to setup the Delete Page
        ///  GET: Blog/Home/Delete/{id}
        /// </summary>
        /// <param name="id">The identity of the service that should be deleted</param>
        /// <returns>The page that shows the page to delete the service</returns>
        public async Task<IActionResult> Delete(string id)
        {
            var entity = await _service.GetAsync(id);

            var sb = new StringBuilder();
            sb.Append($"Are you sure you want to delete the {@entity.ProjectName}?");

            var model = new ModalModel()
            {
                HeaderString = sb.ToString(),
                ControllerUrl = "/Projects/Home/Delete",
                EntityId = entity.Id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// The method used to setup the Delete Page
        ///  GET: Blog/Home/Delete/{id}
        /// </summary>
        /// <param name="id">The identity of the service that should be deleted</param>
        /// <returns>The page that shows the page to delete the post</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _service.DeleteAsync(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
        
        #region Ajax Actions

        /// <summary>
        /// The ajax call to remove a image from the post
        /// </summary>
        /// <param name="id">the identity of the image being removed</param>
        /// <returns>A json string to indicate whether the removal was successful or not</returns>
        [HttpPost]
        public ActionResult RemoveImageAjax(string id)
        {
            _service.RemoveImage(id);
            // return success if successfull
            return Json("success");
        }

        /// <summary>
        /// The ajax method to populate the sub category field of a view
        /// </summary>
        /// <param name="id">The identity of the parent category</param>
        /// <returns>The patent categories sub-categories</returns>
        public ActionResult GetSubCategoryByCategoryId(string id)
        {
            // Get a list of all the blog sub-categories in json format
            var y = Json(from obj in _service.GetSubCategories(id) select new {obj.Entity.Id, obj.Category.Name });
            // Return the Json
            return y;
        }

        #endregion
    }
}