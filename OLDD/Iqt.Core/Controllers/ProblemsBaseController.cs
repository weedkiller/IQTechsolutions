using System.Linq;
using System.Threading.Tasks;
using Iqt.Base.Models;
using Iqt.Grouping.Data;
using Iqt.Grouping.Entities;
using Iqt.Troubleshooting.Entities;
using Iqt.Troubleshooting.Data;
using Iqt.Troubleshooting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ReSharper disable Mvc.ActionNotResolved
// ReSharper disable Mvc.PartialViewNotResolved

// ReSharper disable Mvc.ViewNotResolved

namespace Iqt.Troubleshooting.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// The Troubleshooting problems controller
    /// </summary>
    [Area("Troubleshooting")]
    public class ProblemsBaseController : Controller
    {
        protected readonly ProblemsContext _service;
        protected readonly CategoryContext<Problem> _categoryService;

        #region Constructors

        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected context service</param>
        public ProblemsBaseController(ProblemsContext service, CategoryContext<Problem> categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        #endregion

        #region Index

        /// <summary>
        /// Gets the index page
        /// </summary>
        /// <returns>The index view and model</returns>
        public async Task<IActionResult> Index(string searchText, string categoryId)
        {
            var problems = await _service.GetAll().ToListAsync();

            if (!string.IsNullOrEmpty(categoryId))
            {
                var collection = from item in problems
                    from category in item.Categories
                    where category.CategoryId == categoryId
                    select item;

                problems = collection.ToList();
            }
            if (!string.IsNullOrEmpty(searchText))
            {
                problems = problems.Where(c => c.Description.Contains(searchText)).ToList();
            }

            var model = new ProblemIndexModel(problems)
            {
                Categories = _categoryService.GetAll(),
                SearchText = searchText
            };

            return View(model);
        }

        /// <summary>
        /// Post the Index Page model to the server
        /// </summary>
        /// <param name="model">The model to be posted</param>
        /// <returns>The index view with search results</returns>
        [HttpPost]
        public IActionResult Index(ProblemIndexModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home", new { searchText = model.SearchText });
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region List

        /// <summary>
        /// Gets the list page
        /// </summary>
        /// <returns>The list view and model</returns>
        public async Task<IActionResult> List(string searchText, string categoryId)
        {
            var problems = await _service.GetAll().ToListAsync();

            if (!string.IsNullOrEmpty(categoryId))
            {
                var collection = from item in problems
                    from category in item.Categories
                    where category.CategoryId == categoryId
                    select item;

                problems = collection.ToList();
            }
            if (!string.IsNullOrEmpty(searchText))
            {
                problems = problems.Where(c => c.Description.Contains(searchText)).ToList();
            }

            var model = new ProblemIndexModel(problems)
            {
                Categories = _categoryService.GetAll(),
                SearchText = searchText
            };

            return View(model);
        }

        #endregion

        #region Create Product

        /// <summary>
        /// Gets the create view
        /// </summary>
        /// <returns>The create view with its model</returns>
        public async Task<IActionResult> Create(string categoryId)
        {
            var model = new ProblemAddEditModel(new Problem(), _categoryService.GetAll());
            model.SelectedCategoryIds.Add(categoryId);
            return View(model);
        }

        /// <summary>
        /// Posts the model to the server
        /// </summary>
        /// <param name="model">the model that must be posted to the server</param>
        /// <returns>returns the relevant view depending which button is pressed</returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProblemAddEditModel model, string finnish, string main)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                await _service.AddAsync(model.Entity);

                foreach (var item in model.AvailableCategories)
                {
                    if (item.IsSelected)
                    {
                        var newCat = new EntityCategory<Problem>()
                        {
                            CategoryId = item.Identity.ToString(),
                            EntityId = model.Entity.Id
                        };
                        await _service.AddCategory(newCat);
                    }
                }
                
                if (!string.IsNullOrEmpty(main))
                {
                    return RedirectToAction("Edit", "Home", new { id = model.Entity.Id});
                }
                return RedirectToAction("List");
            }
            return View(model);
        }

        #endregion

        #region Details

        /// <summary>
        /// Gets the edit view and model
        /// </summary>
        /// <param name="id">The id of the entity to be edited</param>
        /// <returns>The edit view and relevant model</returns>
        public async Task<IActionResult> Details(string id)
        {
            // Check to see if id is populated
            if (id == null)
            {
                return NotFound();
            }

            // Finds the correct product category
            var problem = await _service.GetAsync(id);

            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }

        #endregion

        #region Edit 

        /// <summary>
        /// Gets the edit view and model
        /// </summary>
        /// <param name="id">The id of the entity to be edited</param>
        /// <returns>The edit view and relevant model</returns>
        public async Task<IActionResult> Edit(string id)
        {
            // Check to see if id is populated
            if (id == null)
            {
                return NotFound();
            }

            // Finds the correct product category
            var problem = await _service.GetAll().Include(c => c.Categories).Include(c => c.Causes).ThenInclude(c => c.CorrectiveActions).FirstOrDefaultAsync(c => c.Id == id);

            if (problem == null)
            {
                return NotFound();
            }

            var model = new ProblemAddEditModel(problem, _categoryService.GetAll());

            return View(model);
        }
        /// <summary>
        /// Posts the edit model to the server
        /// </summary>
        /// <param name="id">The id of the entity to be updated</param>
        /// <param name="model">The model that the post is being updated from</param>
        /// <param name="addCause">The add cause button value</param>
        /// <param name="addAction">The add action button value</param>
        /// <param name="main">The main submit button value</param>
        /// <returns>The relevant edit view depending on which button was pressed</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProblemAddEditModel model, string main)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model.AvailableCategories)
                {
                    await _service.ProcessAvailableCategories(model.Entity.Id, item);
                }
                
                await _service.UpdateAsync(model.Entity);

                if (main != null)
                {
                    return RedirectToAction("Edit", "Home", new { area="Troubleshooting", id = model.Entity.Id });
                }
                return RedirectToAction("List");
            }
            return View(model);
        }

        #endregion
        
        #region Delete Product

        #region Delete 

        public async Task<ActionResult> Delete(string id)
        {
            var entity = await _service.GetAsync(id);

            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete problem ? " +
                               $"<br/> with id {entity.Id}",
                ControllerUrl = "/Troubleshooting/Home/Delete",
                EntityId = entity.Id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _service.DeleteAsync(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion

        #endregion

        /// <summary>
        /// Removes a cause
        /// </summary>
        /// <param name="id"></param>
        public void RemoveCause(string id)
        {
            _service.RemoveCause(id);
        }

        /// <summary>
        /// Removes a Corrective action
        /// </summary>
        public void RemoveCorrectiveAction(string id)
        {
            _service.RemoveCorrectiveAction(id);
        }
    }
}
