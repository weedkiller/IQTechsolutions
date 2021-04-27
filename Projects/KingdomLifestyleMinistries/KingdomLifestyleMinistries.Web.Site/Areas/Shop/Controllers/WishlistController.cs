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
    public class WishlistController : Controller
    {
        #region Private Members

        protected IRepositoryManager Manager;
        protected UserManager<ApplicationUser> UserManager;

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="_manager">The injected repository manager</param>
        /// <param name="imageSettings">The product image settings</param>
        public WishlistController(IRepositoryManager _manager)
        {
            Manager = _manager;
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
            var entity = Manager.Repository<WishlistItem>().GetAll().Where(c => c.UserId == userId);
            var model = new IndexModelBase<WishlistItem>(entity.ToList());

            return View(model);
        }

        /// <summary>
        /// Add e-commerce item to shopping cart
        /// </summary>
        /// <param name="id">The identity of the product to be added</param>
        /// <returns>The view from wich the product was added</returns>
        [HttpGet]
        public async Task<IActionResult> AddToWishlist(string id)
        {

            var item = await Manager.Repository<Product>().GetEntityAsync(id);

            var wishlistItem = new WishlistItem()
            {
                UserId = UserManager.GetUserId(User),
                ProductId = id
            };

            Manager.Repository<WishlistItem>().Add(wishlistItem);
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
            var item = await Manager.Repository<WishlistItem>().GetEntityAsync(id, c => c.Product);
            Manager.Repository<WishlistItem>().Delete(item.Id);
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