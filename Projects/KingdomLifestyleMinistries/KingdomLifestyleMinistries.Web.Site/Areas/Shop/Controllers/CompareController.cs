using System.Linq;
using System.Threading.Tasks;
using Iqt.Commerce.Entities;
using Iqt.Identity.Entities;
using Iqt.Inventory.Entities;
using IQTechSolutions.Base.Interfaces;
using IQTechSolutions.Base.Models;
using IQTechSolutions.Filing.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Route("Shop/[controller]/[action]")]
    public class CompareController : Controller
    {
        #region Private Members

        protected IRepositoryManager Manager;
        protected UserManager<ApplicationUser> UserManager;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructors
        /// </summary>
        /// <param name="manager">The injected repository manger</param>
        /// <param name="imageSettings">The injected image settings used for upload</param>
        public CompareController(IRepositoryManager manager)
        {
            Manager = manager;
        }

        #endregion

        /// <summary>
        /// Gets the index page and model
        /// </summary>
        /// <param name="page">The page to be rendered</param>
        /// <param name="size">The size of the page to be rendered</param>
        /// <returns></returns>
        public IActionResult Index(int? page, int? size)
        {
            var userId = UserManager.GetUserId(User);
            var list = Manager.Repository<ComparingItem>().GetAll().Where(c => c.UserId == userId);
            var model = new IndexModelBase<ComparingItem>(list.ToList());
            return View(model);
        }

        /// <summary>
        /// Add e-commerce item to shopping cart
        /// </summary>
        /// <param name="id">The identity of the product to be added</param>
        /// <returns>The view from which the product was added</returns>
        [HttpGet]
        public async Task<IActionResult> Add(string id)
        {

            var item = await Manager.Repository<Product>().GetEntityAsync(id);

            var comparingItem = new ComparingItem()
            {
                UserId = UserManager.GetUserId(User),
                ProductId = id
            };

            Manager.Repository<ComparingItem>().Add(comparingItem);
            await Manager.SaveAsync();

            return Json(new
            {
                id = item.Id,
                imageUrl = item.GetImage(ImageType.Icon),
                name = item.Name
            });
        }

        /// <summary>
        /// Removes a e-commence item from the shopping cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Remove(string id)
        {
            var item = await Manager.Repository<ComparingItem>().GetEntityAsync(id, c => c.Product);
            Manager.Repository<ComparingItem>().Delete(item.Id);
            await Manager.SaveAsync();

            return Json(new
            {
                id = item.Id,
                imageUrl = item.Product.GetImage(ImageType.Icon),
                name = item.Product.Name
            });
        }
    }
}