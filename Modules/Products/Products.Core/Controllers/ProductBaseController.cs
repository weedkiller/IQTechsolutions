

// ReSharper disable Mvc.ViewNotResolved
// ReSharper disable Mvc.AreaNotResolved
// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.ActionNotResolved

using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Grouping.Base.Entities;
using Grouping.Core.Context.Services;
using Identity.Base.Entities;
using Iqt.Base.Enums;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Products.Base.Entities;
using Products.Core.Context.Services;
using Products.Core.Models;

namespace Products.Core.Controllers
{
    [Area("Products")]
    public class ProductBaseController : Controller
    {
        #region Private Members

        /// <summary>
        /// The Blog Context Service for this controller
        /// </summary>
        protected readonly ProductContext Service;

        protected readonly CategoryContext<Product> CategoryService;

        

        #endregion

        #region Constructor

        /// <summary>
        /// The default constructor with injected parameters
        /// </summary>
        /// <param name="service">The context service</param>
        /// <param name="categoryService">The injected category service</param>
        public ProductBaseController(ProductContext service, CategoryContext<Product> categoryService)
        {
            Service = service;
            CategoryService = categoryService;
        }

        #endregion

        #region Index

        /// <summary>
        /// Set up the index model and view
        /// </summary>
        /// <param name="categoryId">The category identity filter</param>
        /// <param name="size">The size fo the page</param>
        /// <param name="page">The page number</param>
        /// <param name="sort">The sort order</param>
        /// <returns>the index view</returns>
        [AllowAnonymous]
        public virtual async Task<IActionResult> Index(string categoryId, int? size, int? page, int? sort)
        {
            var services = await Service.GetAll().OrderByDescending(c => c.Created).ToListAsync();

            if (categoryId != null)
            {
                services = (from service in services
                    from category in service.Categories
                    where category.CategoryId == categoryId
                    select service).ToList();
            }

            var model = new ProductIndexModel(services, size, page, sort);

            if (sort != null)
            {
                switch ((SortOrder) sort)
                {
                    case SortOrder.NameAssending:
                        model.All = model.All.OrderBy(c => c.Name).ToList();
                        break;
                    case SortOrder.NameDesending:
                        model.All = model.All.OrderByDescending(c => c.Name).ToList(); 
                        break;
                    case SortOrder.PriceAssending:
                        model.All = model.All.OrderBy(c => c.PriceIncl).ToList(); 
                        break;
                    case SortOrder.PriceDescending:
                        model.All = model.All.OrderByDescending(c => c.PriceIncl).ToList(); 
                        break;
                    //case SortOrder.RatingAssending:
                    //    model.All = model.All.OrderBy(c => c.Reviews.Sum(g => g.Rating)).ToList(); ;
                    //    break;
                    //case SortOrder.RatingDescending:
                    //    model.All = model.All.OrderByDescending(c => c.Reviews.Sum(g => g.Rating)).ToList(); ;
                    //    break;
                }
            }

            var collection = CategoryService.GetAll();
            model.Categories = collection.ToList();

            // Return the view with the model
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Used(int? size, int? page)
        {
            var services = await Service.GetAll().Where(c => c.ProductType == ProductType.Used).ToListAsync();

            var model = new ProductIndexModel(services, size, page)
            {
                Categories = Service.GetAllCategories().ToList()
            };

            // Return the view with the model
            return View(model);
        }

        #endregion

        /// <summary>
        /// Sets up a list view for the services
        /// </summary>
        /// <returns>the index list view</returns>
        public async Task<IActionResult> List(int? page)
        {
            var list = await Service.GetAll().ToListAsync();
            if (!User.IsInRole("Admin") && User.IsInRole("Seller"))
            {
                list = list.Where(c => c.CreatedBy == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            }
            // Get a list of the entries
            

            var model = new ProductIndexModel(list, 12, page);

            // Returns the list view and the model
            return View(model);
        }

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
            var productList = await Service.GetAll().ToListAsync();
            // Get the specific blog entry
            var product = await Service.GetAsync(id);

            // Setup the blog entry details page model
            var model = new ProductDetailsPageModel()
            {
                Product = product,
                ProductCategories = CategoryService.GetAll(),
                FeaturedProducts = productList.OrderBy(c => c.Created),
                Tags = product.Tags,
                PopularVideoUrl = "https://www.youtube.com/watch?v=LOtThFM7cT4",
                PreviousProduct = await Service.GetNextAsync(product),
                NextProduct = await Service.GetNextAsync(product)
            };

            // return the detail view with model
            return View(model);
        }

        /// <summary>
        /// Setup the model/view with a specific service
        /// </summary>
        /// <param name="id">The id of the service that needs to be displayed</param>
        /// <returns>The service view and model</returns>
        [AllowAnonymous]
        public async Task<IActionResult> QuickView(string id)
        {
            // Test to see if the id field is populated
            if (id == null)
            {
                return NotFound();
            }

            // Get the specific blog entry
            var product = await Service.GetAsync(id);

            // return the detail view with model
            return View(product);
        }

        #region Create        

        /// <summary>
        /// Creates a new service
        /// </summary>
        /// <returns>The create view and model</returns>
        public async Task<IActionResult> Create(string returnUrl)
        {
            // Setup the blog entry edit model
            var model = new ProductAddEditModel(new Product(), (CategoryService.GetAll()).Where(c => c.ParentCategoryId == null).ToList())
            {
                Brands = Service.GetAllBrands().ToList(),
                ReturnUrl = returnUrl
            };

            // returns the create view with model
            return View(model);
        }

        /// <summary>
        /// The method used to post to the created service to the server
        /// POST: Blog/Home/Create
        /// </summary>
        /// <param name="model">the model of the service that should be added</param>
        /// <param name="finnish">The secondary submit button value</param>
        /// <param name="addFeature"></param>
        /// <param name="main">The main submit button value</param>
        /// <returns>The create view and model</returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProductAddEditModel model, string addFeature, string main, string finnish)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                model.Entity.SetCreation(User.FindFirstValue(ClaimTypes.NameIdentifier));
                await Service.AddAsync(model);

                foreach (var item in model.AvailableCategories)
                {
                    if (item.IsSelected)
                    {
                        var newCat = new EntityCategory<Product>()
                        {
                            CategoryId = item.Identity.ToString(),
                            EntityId = model.Entity.Id
                        };
                        await CategoryService.AddEntityCategory(newCat);
                    }
                }

                if (!string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction(model.ReturnUrl);
                }
                // if main submit button is clicked
                if (finnish != null)
                {
                    // return the entry list view
                    return RedirectToAction(nameof(List));
                }
                if (main != null)
                {
                    // return the entry list view
                    return RedirectToAction(nameof(Edit), "Home", new { area = "Products", id = model.Entity.Id });
                }

                //if secondary submit button is clicked
                if (addFeature != null)
                {
                    // return the category edit view
                    return RedirectToAction(nameof(Create), "Features", new { area = "Products", productId = model.Entity.Id });
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
            var product = await Service.GetAll().OrderBy(c => c.Created).FirstOrDefaultAsync(c => c.Id == id);

            // Check if the blogentry exist
            if (product == null)
            {
                return NotFound();
            }

            // Setup the new model for the page
            var model = new ProductAddEditModel(product, CategoryService.GetAll());

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
        public async Task<IActionResult> Edit(ProductAddEditModel model, string addFeature, string main, string finnish)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                model.Entity.SetModification(User.FindFirstValue(ClaimTypes.NameIdentifier));

                //await CategoryService.ProcessAvailableCategories(model.Entity.Id, item);

                await CategoryService.ProcessEntityCategories(model.Entity.Id, model.AvailableCategories);

                await Service.UpdateAsync(model);

                // if main submit button is clicked
                if (finnish != null)
                {
                    // return the entry list view
                    return RedirectToAction(nameof(List));
                }
                if (main != null)
                {
                    // return the entry list view
                    return RedirectToAction(nameof(Edit), "Home", new { area = "Products", id = model.Entity.Id });
                }

                //if secondary submit button is clicked
                if (addFeature != null)
                {
                    // return the category edit view
                    return RedirectToAction(nameof(Create), "FeatureBase", new { area = "Products", productId = model.Entity.Id });
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
            var entity = await Service.GetAsync(id);

            var sb = new StringBuilder();
            sb.Append("Are you sure you want to delete answer ?");
            sb.AppendLine(); 
            sb.Append($"with id {entity.Id}");
            

            var model = new ModalModel()
            {
                HeaderString = sb.ToString(),
                ControllerUrl = "/Products/Home/Delete",
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
            await Service.DeleteAsync(id);
            
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion

        #region Categories

        /// <summary>
        /// Gets a <see cref="Problem"/> collection from the database that belongs to a specific <see cref="Category{T}"/>
        /// </summary>
        /// <param name="categoryId">The identity of the <see cref="Category{T}"/> that the <see cref="Problem"/> collection belongs to</param>
        /// <returns>A <see cref="Problem"/> collection</returns>
        public IQueryable<EntityCategory<Product>> GetCategoryProblems(string categoryId)
        {
            return CategoryService.GetEntityCategories(categoryId);
        }

        /// <summary>
        /// Gets a specific <see cref="EntityCategory{T}"/> category problem
        /// </summary>
        /// <param name="problemId">The identity of the <see cref="Problem"/> that belongs to the <see cref="Category{T}"/></param>
        /// <param name="categoryId">The identity of the <see cref="Category{T}"/> that the problem belongs to</param>
        /// <returns>The specific <see cref="EntityCategory{T}"/> problem category</returns>
        public Task<EntityCategory<Product>> GetEntityCategory(string problemId, string categoryId)
        {
            return Task.FromResult(CategoryService.GetEntityCategories(categoryId).Where(c => c.EntityId == problemId).FirstOrDefault(c => c.CategoryId == categoryId));
        }

        /// <summary>
        /// Processes a <see cref="CheckBoxSelectionModel{T}"/> for addition as a <see cref="EntityCategory{T}"/>
        /// to add to the database as a problem category
        /// </summary>
        /// <param name="parentId">The identity of the parent <see cref="Problem"/></param>
        /// <param name="item">The identity of the <see cref="Category{T}"/></param>
        public async Task ProcessAvailableCategories(string parentId, CheckBoxSelectionModel<Category<Product>> item)
        {
            if (item.HasChildSelection)
            {
                foreach (var ss in item.ChildSelection)
                {
                    await ProcessAvailableCategories(parentId, ss);
                }

            }

            var entityCategory = await GetEntityCategory(parentId, item.Identity);

            if (item.IsSelected && entityCategory == null)
            {
                var newCat = new EntityCategory<Product>
                {
                    CategoryId = item.Identity,
                    EntityId = parentId
                };

                // problem.Categories.Add(newCat);
                await CategoryService.AddEntityCategory(newCat);
            }

            if (!item.IsSelected && entityCategory != null)
            {
                await CategoryService.RemoveEntityCategory(entityCategory);
            }
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
            var y = Json(Service.GetAll().Select(obj => new {obj.Id, obj.Name}));
            // Return the Json
            return y;
        }

        #endregion
    }
}
