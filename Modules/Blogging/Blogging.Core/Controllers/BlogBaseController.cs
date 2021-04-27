using System;
using System.Linq;
using System.Threading.Tasks;
using Blogging.Base.Entities;
using Blogging.Core.Context.Services;
using Blogging.Core.Models;
using Grouping.Core.Context.Services;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Core.Controllers
{
    public class BlogBaseController : Controller
    {
        protected readonly BlogContext Service;
        protected readonly CategoryContext<BlogPost> CategoryService;

        #region Constructors

        /// <summary>
        /// The default constructor with injected parameters
        /// </summary>
        /// <param name="service">The context service for this controller</param>
        /// <param name="userManager">The injected user manager</param>
        /// <param name="signInManager">The injected sign in manager</param>
        /// <param name="categoryService">The injected category context service</param>
        public BlogBaseController(BlogContext service, CategoryContext<BlogPost> categoryService)
        {
            Service = service;
            CategoryService = categoryService;
        }

        #endregion

        #region Lists

        /// <summary>
        /// Set up the index model and view
        /// </summary>
        /// <param name="month">The month to filter by</param>
        /// <param name="size">The size fo the page</param>
        /// <param name="page">The page number</param>
        /// <returns>the index view</returns>
        [AllowAnonymous]
        public IActionResult Index(int? month, string category, string tagString, int? size, int? page)
        {
            // Set default page size to 12 if parameter is null
            int pageSize = (size ?? 12);
            // Set the default page number to the first parameter is value is null
            int pageNumber = (page ?? 1);

            // Get the correct entry
            var blogEntryList = Service.GetAll().Where(c => c.Active).OrderBy(c => c.Modified).ThenBy(c => c.Created)
                .ToList();

            // if month parameter is not null
            if (month != null)
                // Filter the entrylist to entries containing this month value
                blogEntryList = Service.GetAllByMonth(month.Value).OrderByDescending(c => c.Created).ToList();

            // if month parameter is not null
            if (!string.IsNullOrEmpty(category))
                // Filter the entrylist to entries containing this month value
                blogEntryList = (from ent in blogEntryList
                                 from ca in ent.Categories
                                 where ca.CategoryId == category
                                 select ent).ToList();

            // Get a list of all the blog categories
            var categoryList = Service.GetCategories();

            // Set up the model for the index page
            var model = new BlogIndexPageModel(blogEntryList)
            {
                PageCount = pageNumber,
                PageSize = pageSize,
                BlogCategories = categoryList.OrderBy(c => c.Name),
                FeaturedBlogEntries = blogEntryList.Take(3),
                RecentBlogEntries = blogEntryList.OrderByDescending(c => c.Created).Take(3)
            };

            // Return the view with the model
            return View(model);
        }

        /// <summary>
        /// Sets up a list view for the blog entries
        /// </summary>
        /// <returns>the index list view</returns>
        public IActionResult List()
        {
            // Get a list of the entries
            var list = Service.GetAll().ToList();

            var model = new BlogIndexPageModel(list);

            // Returns the list view and the model
            return View(model);
        }

        #endregion

        #region Details

        /// <summary>
        /// Setup the blog details view with a specific blog entry
        /// </summary>
        /// <param name="id">The id of the category that needs to be displayed</param>
        /// <returns>The blog details view</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            // Test to see if the id field is populated
            if (id == null)
            {
                return NotFound();
            }

            // Get a list of all blog entries
            var blogEntryList = await Service.GetAll().Include(c => c.Images).ToListAsync();
            // Get the specific blog entry
            BlogPost blogEntry = Service.GetAll().Include(c => c.Images).FirstOrDefault(c => c.Id == id);

            // Setup the blog entry details page model
            var model = new BlogEntryDetailsPageModel(blogEntry)
            {
                BlogCategories = Service.GetCategories(),
                FeaturedBlogEntries = blogEntryList.Where(c => c.Id != id).OrderBy(c => c.Created),
                Tags = blogEntry.Tags,
                PopularVideoUrl = "https://www.youtube.com/watch?v=LOtThFM7cT4",
                Previous = await Service.GetPreviousAsync(blogEntry),
                Next = await Service.GetNextAsync(blogEntry)
            };

            //if (SignInManager.IsSignedIn(User))
            //{
            //    model.CommentModel.Comment.SetUser(await UserManager.GetUserAsync(User));
            //}

            // return the detail view with model
            return View(model);
        }

        #endregion

        #region Create        

        /// <summary>
        /// Creates a new blog entry
        /// </summary>
        /// <param name="parentId">The id of the parent blog entry</param>
        /// <returns></returns>
        public async Task<IActionResult> Create(string parentId)
        {
            var newEntity = new BlogPost()
            {
                Id = Guid.NewGuid().ToString()
            };

            // Setup the blog entry edit model
            var model = new BlogPostAddEditModel(newEntity, CategoryService.GetAll());

            // returns the create view with model
            return View(model);
        }

        /// <summary>
        /// The method used to post to the create post to the server
        /// POST: Blog/Home/Create
        /// </summary>
        /// <param name="model">the model of the post that should be added</param>
        /// <param name="sub">The secondary submit button value</param>
        /// <param name="main">The main submit button value</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPostAddEditModel model, string sub, string main, string finnish)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                if (finnish != null)
                {
                    model.Entity.Active = true;
                }

                await Service.AddAsync(model);

                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Home", new { id = model.Entity.Id });
                }

                if (finnish != null)
                {
                    // return the entry list view
                    return RedirectToAction(nameof(List));
                }

                //if secondary submit button is clicked
                if (sub != null)
                {
                    // return the category edit view
                    return RedirectToAction(nameof(Create), "Home", new { area = "Blog", id = model.Entity.Id });
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
            var blogPost = await Service.GetAsync(id);

            // Check if the blogentry exist
            if (blogPost == null)
            {
                return NotFound();
            }

            var categories = CategoryService.GetAll();

            // Setup the new model for the page
            var model = new BlogPostAddEditModel(blogPost, categories);

            return View(model);
        }

        /// <summary>
        /// The method used to post to the update post to the server
        /// POST: Blog/Home/Edit/{id}
        /// </summary>
        /// <param name="model">The model that the post is being updated from</param>
        /// <param name="sub">The add Comment button</param>
        /// <param name="main">The main submit button</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogPostAddEditModel model, string sub, string main, string finnish)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                if (finnish != null)
                {
                    model.Entity.Active = true;
                }

                await Service.UpdateAsync(model);

                // if main submit button is clicked
                if (main != null)
                {
                    return RedirectToAction(nameof(Edit), "Home", new { area = "Blog", id = model.Entity.Id });
                }

                if (finnish != null)
                {
                    // Redirect to the index page
                    return RedirectToAction(nameof(List));
                }

                //if secondary submit button is clicked
                if (sub != null)
                {
                    // Redirect to the Edit page
                    return RedirectToAction(nameof(Create), "Home", new { area = "Services", id = model.Entity.Id });
                }

                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        #endregion

        #region Delete 

        /// <summary>
        /// Opens the Delete blog entry modal
        /// </summary>
        /// <param name="id">The identity of the blog entry to be deleted</param>
        /// <returns>A task of action result</returns>
        public async Task<ActionResult> Delete(string id)
        {
            var entity = await Service.GetAsync(id);

            var model = new ModalModel()
            {
                HeaderString = $"Are you sure you want to delete Blog Entry with id {entity.Id}",
                ControllerUrl = "/Blog/Home/Delete",
                EntityId = entity.Id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// The delete confirmed from the modal
        /// </summary>
        /// <param name="id">The identity of the blog to be confirmed</param>
        /// <returns>returns a task of actionresult</returns>
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
            var y = Json(from obj in Service.GetSubCategories(id) select new { obj.Id, obj.Name });
            // Return the Json
            return y;
        }

        #endregion
    }
}
