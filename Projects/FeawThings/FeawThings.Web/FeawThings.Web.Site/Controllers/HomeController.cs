using FeawThings.Web.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Authorization;

namespace FeawThings.Web.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult ClientZone()
        {
            return View();
        }

        public IActionResult ComingSoon()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            return SignOut("Cookie", "oidc");
        }

        /// <summary>
        /// The method used to setup the Delete Page
        ///  GET: Blog/Home/Delete/{id}
        /// </summary>
        /// <param name="id">The identity of the service that should be deleted</param>
        /// <returns>The page that shows the page to delete the service</returns>
        public async Task<IActionResult> CropImage(string cropUrl, string originalUrl, int width, int height,
            string previewClass, string uploadProperty, string xTag, string yTag, string widthTag, string heightTag,
            string rotateTag, string scaleXTag, string scaleYTag)
        {
            var model = new CropModel
            {
                CropImageUrl = cropUrl,
                OriginalImageUrl = originalUrl,
                MinWidth = width,
                MinHeight = height,
                PreviewClass = previewClass,
                UploadProperty = uploadProperty,
                XTag = xTag,
                YTag = yTag,
                WidthTag = widthTag,
                HeightTag = heightTag,
                RotateTag = rotateTag,
                ScaleXTag = scaleXTag,
                ScaleYTag = scaleYTag
            };
            return PartialView("Modals/_CropModal", model);
        }
    }
}
