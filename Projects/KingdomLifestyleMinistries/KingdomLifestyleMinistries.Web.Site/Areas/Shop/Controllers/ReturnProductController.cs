using IQTechSolutions.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Route("Shop/[controller]/[action]")]
    public class ReturnProductController : Controller
    {
        #region Private Members

        /// <summary>
        /// The application repository manager
        /// </summary>
        protected IRepositoryManager Manager;

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="manager">The injected repository manager</param>
        public ReturnProductController(IRepositoryManager manager)
        {
            Manager = manager;
        }

        #endregion

        #region Lists

        /// <summary>
        /// Gets the index page and the model
        /// </summary>
        /// <param name="page">The page to be rendered</param>
        /// <param name="size">The size of the page to be rendered</param>
        /// <returns></returns>
        public IActionResult Index(int? page, int? size)
        {
            return View();
        }

        #endregion
    }
}