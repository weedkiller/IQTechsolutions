using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IQTechSolutions.Web.Site.Models;

namespace IQTechSolutions.Web.Site.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Attempts to locate the index view
        /// </summary>
        /// <returns>the index view</returns>
        public IActionResult Index()
        {
            return View("Index");

        }

        /// <summary>
        /// Attempts to locate the about us view
        /// </summary>
        /// <returns>the about us view</returns>
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Attempts to locate the vacancies view
        /// </summary>
        /// <returns>the about us view</returns>
        public IActionResult Vacancies()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Attempts to locate the view that explains the the terms and conditions for use of this website
        /// </summary>
        /// <returns>the view that explains the the terms and conditions for use of this website</returns>
        public ActionResult Terms()
        {
            return View();
        }

        /// <summary>
        /// Attempts to locate the view that explains the privacy policy
        /// </summary>
        /// <returns>the view that explains the privacy policy</returns>
        public ActionResult CookieUse()
        {
            return View();
        }

        /// <summary>
        /// Attempts to locate the view that explains the privacy policy
        /// </summary>
        /// <returns>the view that explains the privacy policy</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Attempts to locate the view that explains the our acceptable usage policy
        /// </summary>
        /// <returns>the view that explains our acceptable usage policy</returns>
        public ActionResult AcceptableUsagePolicy()
        {
            return View();
        }

        /// <summary>
        /// Attempts to locate the view that is displayed when the specific page is under construction
        /// </summary>
        /// <returns>the under construction view</returns>
        public ActionResult UnderConstruction()
        {
            return View();
        }

        /// <summary>
        /// This method runs when there was an unexpected error in the web site
        /// </summary>
        /// <returns>a page that explains the error that occured</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
