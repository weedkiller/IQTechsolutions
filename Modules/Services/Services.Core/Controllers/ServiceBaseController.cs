// ReSharper disable Mvc.PartialViewNotResolved
// ReSharper disable Mvc.ActionNotResolved
// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.ViewNotResolved
// ReSharper disable Mvc.AreaNotResolved

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Base.Entities;
using Services.Core.Context.Services;
using Services.Core.Models;

namespace Services.Core.Controllers
{
    /// <summary>
    /// The service base controller
    /// </summary>
    [Authorize]
    [Area("Services")]
    [Microsoft.AspNetCore.Components.Route("Services/[controller]/[action]")]
    public class ServiceBaseController : Controller
    {
        protected readonly ServiceContext Service;

        #region Constructor

        /// <summary>
        /// The default constructor with injected parameters
        /// </summary>
        /// <param name="service">The injected context service</param>
        public ServiceBaseController(ServiceContext service)
        {
            Service = service;
        }

        #endregion

        #region Index

        /// <summary>
        /// Gets the index model with a list of services
        /// </summary>
        /// <param name="categoryId">The identity of the featured category filter</param>
        /// <param name="size">The amount of items on the page</param>
        /// <param name="page">The current page number</param>
        /// <returns>the index view</returns>
        [AllowAnonymous]
        public virtual IActionResult Index(string categoryId, int? size, int? page)
        {
            var collection = Service.GetAll();

            if (categoryId != null)
            {
                return RedirectToAction("Details", "Categories", new { id = categoryId });
            }

            var model = new ServiceIndexModel(collection.Distinct().ToList())
            {
                PageSize = size ?? 12,
                PageCount = page ?? 1,
                Categories = Service.GetAllCategories().OrderBy(c => c.Created).ToList()
            };

            // Return the view with the model
            return View(model);
        }

        #endregion

        /// <summary>
        /// Sets up the list view model with a list of services
        /// GET: Services/Home/Index?categoryId={categoryId}&size={size}&page={page}
        /// <param name="categoryId">The identity of the featured category filter</param>
        /// <param name="size">The amount of items on the page</param>
        /// <param name="page">The current page number</param>
        /// </summary>
        /// <returns>the index list view</returns>
        public async Task<IActionResult> List(string categoryId, int? size, int? page)
        {
            try
            {
                var services = await Service.GetAll().Where(c => !c.Module).OrderByDescending(c => c.Featured).ThenBy(c => c.Created).ToListAsync();

                if (!string.IsNullOrEmpty(categoryId))
                {
                    var list = from service in services
                        from category in service.Categories
                        where category.CategoryId == categoryId
                               select service;

                    services = list.Distinct().ToList();
                }

                var model = new ServiceIndexModel(services, size, page)
                {
                    Categories = Service.GetAllCategories().ToList(),
                    CategoryFilterId = categoryId
                };

                // Returns the list view and the model
                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Setup the model/view with a specific service
        /// GET: Services/Home/Details?categoryId={categoryId}&size={size}&page={page}
        /// <param name="categoryId">The identity of the featured category filter</param>
        /// <param name="size">The amount of items on the page</param>
        /// <param name="page">The current page number</param>
        /// </summary>
        /// <param name="id">The id of the service that needs to be displayed</param>
        /// <returns>The service details view</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            // Test to see if the id field is populated
            if (id == null)
            {
                return NotFound();
            }

            // Get a list of all blog entries
            var serviceList = await Service.GetAll().Include(c => c.Images).ToListAsync();
            // Get the specific blog entry
            var service = await Service.GetEntityAsync(id);

            // Setup the blog entry details page model
            var model = new ServiceDetailsPageModel(service)
            {
                FeaturedServices = serviceList
            };

            // return the detail view with model
            return View(model);
        }

        #region Create        

        /// <summary>
        /// Creates a new service model with a list of categories and a new service
        /// GET: Services/Home/Create
        /// </summary>
        /// <returns>The create view</returns>
        public IActionResult Create()
        {
            // Setup the blog entry edit model
            var model = new ServiceAddEditModel(new Service(), Service.GetAllCategories());

            // returns the create view with model
            return View(model);
        }

        /// <summary>
        /// The method used to post to the created service to the server
        /// POST: Services/Home/Create
        /// </summary>
        /// <param name="model">the model of the service that should be added</param>
        /// <param name="main">The main submit button value</param>
        /// <returns>The create view and model</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceAddEditModel model, string main)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                await Service.AddOrUpdateAsync(model);

                // if main submit button is clicked
                if (main != null)
                {
                    // return the entry list view
                    return RedirectToAction(nameof(Edit), "Home", new {id=model.Entity.Id});
                }

                return RedirectToAction(nameof(List));
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
            var blogPost = await Service.GetEntityAsync(id);

            // Check if the blogentry exist
            if (blogPost == null)
            {
                return NotFound();
            }

            // Setup the new model for the page
            var model = new ServiceAddEditModel(blogPost, Service.GetAllCategories());


            return View(model);
        }

        /// <summary>
        /// The method used to post to the updated service to the server
        /// </summary>
        /// <param name="model">The model that the post is being updated from</param>
        /// <param name="addFeature">The add feature button value</param>
        /// <param name="main">The main submit button</param>
        /// <returns>The List/Edit view</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceAddEditModel model, string main)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                var blogpost = await Service.AddOrUpdateAsync(model);

                // if main submit button is clicked
                if (main != null)
                {
                    // Redirect to the index page
                    return RedirectToAction(nameof(Edit), "Home", new {area="Services", id = blogpost.Id});
                }
                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        #endregion

        #region Tasks

        /// <summary>
        /// The method to setup the create view
        /// </summary>
        /// <param name="parentId">The identity of the question this answer belongs to</param>
        /// <returns>The create view</returns>
        public async Task<IActionResult> CreateTask(string projectId)
        {
            // Create new answer
            var model = new IncludeServiceModel()
            {
                ParentServiceId = projectId
            };
            // Return the view
            return PartialView("_IncludeServiceModal", model);
        }

        /// <summary>
        /// The method to post the new faq answer to the server
        /// </summary>
        /// <param name="faqAnswer">the answer to post to the server</param>
        /// <returns>The index view if successful otherwise the same view with errors</returns>
        [HttpPost]
        public async Task<IActionResult> CreateTask(IncludeServiceModel model)
        {
            // Check for validation errors
            //if (ModelState.IsValid)
            //{
            //    var task = await Service.AddTaskAsync(model);


            //    return Json(new { id = task.Task.Id, heading = task.Task.Heading, completed = false });
            //}
            return View("_CreateTaskModal", model);
        }

        #endregion
        
        #region Delete 

        public async Task<ActionResult> Delete(string id)
        {
            var entity = await Service.GetEntityAsync(id);

            var sb = new StringBuilder();
            sb.Append($"Are you sure you want to delete the {@entity.Name}?");

            var model = new ModalModel()
            {
                HeaderString = sb.ToString(),
                ControllerUrl = "/Services/Home/Delete",
                EntityId = entity.Id
            };

            return PartialView("Modals/_DeleteModal", model);
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

        #region Delete Included Service

        public async Task<ActionResult> DeleteComboCategory(string id)
        {
            //var entity = await Service.GetIncludedAsync(id);

            //var sb = new StringBuilder();
            //sb.Append("Are you sure you want to delete the included service ?");

            //var model = new ModalModel()
            //{
            //    HeaderString = sb.ToString(),
            //    ControllerUrl = "/Services/Home/DeleteIncluded",
            //    EntityId = entity.Id
            //};

            return PartialView("Modals/_DeleteModal");
        }

        [HttpPost, ActionName("DeleteComboCategory")]

        public async Task<ActionResult> DeleteComboCategoryConfirmed(string comboId, string categoryId)
        {
            await Service.RemoveCombo(comboId, categoryId);
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
            Service.RemoveImage(id);

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
            var y = Json(from obj in Service.GetParentAllCategories(id) select new {obj.Id, obj.Name });
            // Return the Json
            return y;
        }

        /// <summary>
        /// The ajax method to populate the sub category field of a view
        /// </summary>
        /// <param name="id">The identity of the parent category</param>
        /// <returns>The patent categories sub-categories</returns>
        public ActionResult GetServiceByCategoryId(string id)
        {
            var list = Service.GetByCategory(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(from obj in list  select new { obj.Id, obj.Name });
            // Return the Json
            return y;
        }

        #endregion

        [AllowAnonymous]
        public IActionResult PricingList()
        {
            var list = Service.GetAll().Where(c => c.PriceTableItem).OrderBy(c => c.Price);
            return View(list);
        }
    }
}
