using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grouping.Base.Entities;
using Grouping.Core.Context.Services;
using Grouping.Core.Models;
using Iqt.Base.BaseTypes;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Grouping.Core.Controllers
{
    /// <summary>
    /// The base category controller
    /// </summary>
    /// <typeparam name="T">The type that will be owned by the <see cref="Category{T}"/></typeparam>
    public class CategoryBaseController<T> : Controller where T : EntityBase, new()
    {
        /// <summary>
        /// The context service
        /// </summary>
        protected readonly CategoryContext<T> Service;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service">The injected category context service</param>
        public CategoryBaseController(CategoryContext<T> service)
        {
            Service = service;
        }

        /// <summary>
        /// Set up the index model and view
        /// </summary>
        /// <param name="id">The month to filter by</param>
        /// <param name="size">The size fo the page</param>
        /// <param name="page">The page number</param>
        /// <returns>the index view</returns>
        [AllowAnonymous]
        public virtual async Task<IActionResult> Index(string id, int? size, int? page)
        {
            // Get the correct entry
            var entity = await Service.GetAsync(id);
            // Set up the model for the index page
            var model = new CategoryDetailsModel<T>(entity);

            // Return the view with the model
            return View(model);
        }

        /// <summary>
        /// Sets up a list view for the blog entries
        /// </summary>
        /// <returns>the index list view</returns>
        public async Task<IActionResult> List()
        {
            // Get a list of the entries
            var listByDescending = (Service.GetAllCategories().Where(c => c.ParentCategoryId == null)).OrderByDescending(c => c.Created);
            var model = new CategoryIndexModel<T>(listByDescending.ToList());


            // Returns the list view and the model
            return View(model);
        }

        /// <summary>
        /// Setup the blog details view with a specific blog entry
        /// </summary>
        /// <param name="id">The id of the category that needs to be displayed</param>
        /// <returns>The blog details view</returns>
        [AllowAnonymous]
        public virtual async Task<IActionResult> Details(string id)
        {
            // Test to see if the id field is populated
            if (id == null)
            {
                return NotFound();
            }

            // Get the specific blog entry
            var category = (Service.GetAll()).FirstOrDefault(c => c.Id == id);

            // Setup the blog entry details page model
            var model = new CategoryDetailsModel<T>(category)
            {
                Next = await Service.GetNextAsync(category),
                Previous = await Service.GetPreviousAsync(category)
            };

            // return the detail view with model
            return View(model);
        }

        #region Create   

        /// <summary>
        /// Creates a new blog entry
        /// </summary>
        /// <returns></returns>
        public IActionResult Create(string parentId, string departmentId)
        {
            // Setup the blog entry edit model
            var model = new CategoryAddEditModel<T>()
            {
                Entity = new Category<T>()
                {
                    Id = Guid.NewGuid().ToString(),
                    ParentCategoryId = parentId,
                    DepartmentId = departmentId
                },
                ParentId = parentId,
                Departments = Service.GetAllDepartments().ToList()
            };

            // returns the create view with model
            return View(model);
        }

        /// <summary>
        /// The method used to post to the create post to the server
        /// POST: Blog/Home/Create
        /// </summary>
        /// <param name="model">the model of the post that should be added</param>
        /// <param name="finnish">The finnish button value</param>
        /// <param name="main">The main submit button value</param>
        /// <param name="sub">The sub category button value</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(CategoryAddEditModel<T> model, string main, string finnish, string sub)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                await Service.AddAsync(model);
                
                if (finnish != null)
                {
                    if (model.Entity.DepartmentId != null)
                    {
                        return RedirectToAction(nameof(Edit), "Departments", new { id = model.Entity.DepartmentId });
                    }
                    if (model.Entity.ParentCategoryId != null)
                    {
                        return RedirectToAction(nameof(Edit), "Categories", new { id = model.Entity.ParentCategoryId });
                    }
                    return RedirectToAction(nameof(List), "Categories");
                }
                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Categories", new { id = model.Entity.Id });
                }
                if (sub != null)
                {
                    return RedirectToAction(nameof(Create), "Categories", new { parentId = model.Entity.Id });
                }
            }

            // Returns the view with the model
            return View(model);
        }

        #endregion

        #region Edit

        /// <summary>
        /// The method used to get the edit product view
        /// GET: Blog/Home/Edit/{id}
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

            // Get the correct blog entry
            var category = await Service.GetAsync(id);

            // Check if the blogentry exist
            if (category == null)
            {
                return NotFound();
            }

            // Setup the new model for the page
            var model = new CategoryAddEditModel<T>(category);

            return View(model);
        }

        /// <summary>
        /// The method used to post to the update post to the server
        /// POST: Blog/Home/Edit/{id}
        /// </summary>
        /// <param name="model">The model that the post is being updated from</param>
        /// <param name="main">The main submit button</param>
        /// <param name="finnish">The finnish submit button value</param>
        /// <param name="sub">The subcategory button</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(CategoryAddEditModel<T> model, string main, string finnish, string sub, string prob)
        {
            // Check for any validation errors
              if (ModelState.IsValid)
            {
                await Service.UpdateAsync(model);

                if (finnish != null)
                {
                    if (model.Entity.DepartmentId != null)
                    {
                        return RedirectToAction(nameof(Edit), "Departments", new { id = model.Entity.DepartmentId });
                    }
                    if (model.Entity.ParentCategoryId != null)
                    {
                        return RedirectToAction(nameof(Edit), "Categories", new { id = model.Entity.ParentCategoryId });
                    }
                    return RedirectToAction(nameof(List), "Categories");
                }
                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Categories", new { id = model.Entity.Id });
                }
                if (sub != null)
                {
                    return RedirectToAction(nameof(Create), "Categories", new { parentId = model.Entity.Id, parentCategoryId = model.Entity.Id });
                }
                if (prob != null)
                {
                    return RedirectToAction(nameof(Create), "Home", new { parentId = model.Entity.Id, parentCategoryId = model.Entity.Id });
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
                HeaderString = "Are you sure you want to delete this category category ",
                ControllerUrl = Url.Action("Delete", new {id = id}),
                Parameters = new Dictionary<string, string>()
                {
                    {"categoryId", id }
                }
            };

            return PartialView("Modals/_DeleteObjectModal", model);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<ActionResult> DeleteConfirmed(string id)
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