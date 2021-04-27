using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iqt.Base.BaseTypes;
using Iqt.Base.Models;
using Iqt.Grouping.Entities;
using Iqt.Grouping.Interfaces;
using Iqt.Grouping.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ReSharper disable Mvc.PartialViewNotResolved
// ReSharper disable Mvc.ActionNotResolved
// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.ViewNotResolved

namespace Iqt.Core.Controllers
{
    public class DepartmentBaseController<T> : Controller where T : EntityBase, new()
    {
        /// <summary>
        /// The context service
        /// </summary>
        protected readonly IDepartmentService<T> Service;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service">The injected category context service</param>
        public DepartmentBaseController(IDepartmentService<T> service)
        {
            Service = service;
        }

        /// <summary>
        /// Set up the index model and view
        /// </summary>
        /// <param name="id">The identity of the <see cref="Department{T}"/></param>
        /// <param name="size">The amount of items on the page</param>
        /// <param name="page">The page number</param>
        /// <returns>the index view</returns>
        [AllowAnonymous]
        public virtual async Task<IActionResult> Index(string id, int? size, int? page)
        {
            // Get the correct entry
            var entity = await Service.GetAsync(id);
            // Set up the model for the index page
            var model = new DetailsModelBase<Department<T>>(entity);

            // Return the view with the model
            return View(model);
        }

        /// <summary>
        /// Sets up a list view for the <see cref="Department{T}"/>
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
        /// Setup the details view with a specific <see cref="Department{T}"/>
        /// </summary>
        /// <param name="id">The id of the <see cref="Department{T}"/> that needs to be displayed</param>
        /// <returns>The <see cref="Department{T}"/> details view</returns>
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
            var model = new DetailsModelBase<Department<T>>(category)
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
        public IActionResult CreatePartial()
        {
            // Setup the blog entry edit model
            var model = new DepartmentAddEditModel<T>()
            {
                Entity = new Department<T>()
            };

            // returns the create view with model
            return PartialView("_Create",model);
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
        [HttpPost]
        public IActionResult CreatePartial(DepartmentAddEditModel<T> model, string main, string finnish, string sub)
        {
            // Check for any validation errors
            //if (ModelState.IsValid)
            //{
            //    return Json(await Service.AddAsync(model, ImageSettings, IconImageSettings));
            //}

            // Returns the view with the model
            return View(model);
        }

        /// <summary>
        /// Creates a new blog entry
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            // Setup the blog entry edit model
            var model = new DepartmentAddEditModel<T>();

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
        public virtual async Task<IActionResult> Create(DepartmentAddEditModel<T> model, string main, string finnish, string sub)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                var department = model.Entity;
                department.





                await Service.AddAsync(model);
                
                if (finnish != null)
                {
                    return RedirectToAction(nameof(List), "Departments");
                }
                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Departments", new { id = model.Entity.Id });
                }
                if (sub != null)
                {
                    return RedirectToAction(nameof(Create), "Categories", new { departmentId = model.Entity.Id });
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
        public async Task<IActionResult> EditPartial(string id)
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
            var model = new DepartmentAddEditModel<T>(category);

            return PartialView("_Edit", model);
        }

        /// <summary>
        /// The method used to post to the update post to the server
        /// POST: Blog/Home/Edit/{id}
        /// </summary>
        /// <param name="model">The model that the post is being updated from</param>
        /// <param name="main">The main submit button</param>
        /// <param name="finnish">The finnish submit button value</param>
        /// <param name="sub">The sub category button</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditPartial(DepartmentAddEditModel<T> model, string main, string finnish, string sub)
        {
            // Check for any validation errors
            //if (ModelState.IsValid)
            //{
            //    return Json(Service.UpdateAsync(model, ImageSettings, IconImageSettings));
            //}
            return View(model);
        }

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
            var model = new DepartmentAddEditModel<T>(category);

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
        public virtual async Task<IActionResult> Edit(DepartmentAddEditModel<T> model, string main, string finnish, string sub)
        {
            // Check for any validation errors
              if (ModelState.IsValid)
            {
                await Service.UpdateAsync(model);

                if (finnish != null)
                {
                    return RedirectToAction(nameof(List), "Departments");
                }
                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Departments", new { id = model.Entity.Id });
                }
                if (sub != null)
                {
                    return RedirectToAction(nameof(Create), "Categories", new { departmentId = model.Entity.Id });
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
                ControllerUrl = Url.Action("Delete", new { id }),
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