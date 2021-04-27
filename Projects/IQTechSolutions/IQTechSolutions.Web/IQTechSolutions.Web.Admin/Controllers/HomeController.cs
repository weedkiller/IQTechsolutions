using IQTechSolutions.Web.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Authorization;

namespace IQTechSolutions.Web.Admin.Controllers
{
    [Authorize]
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

        public IActionResult UnderConstruction()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// The method used to setup the Delete Page
        ///  GET: Blog/Home/Delete/{id}
        /// </summary>
        /// <param name="id">The identity of the service that should be deleted</param>
        /// <returns>The page that shows the page to delete the service</returns>
        public async Task<IActionResult> CropImage(string cropUrl,
            string originalUrl,
            int width = 600,
            int height = 400,
            string aspectRatio = "3/2",
            string previewClass = "previewd",
            string uploadProperty = "CoverUpload",
            string xTag = "CoverCropSettings_X",
            string yTag = "CoverCropSettings_Y",
            string widthTag = "CoverCropSettings_Width",
            string heightTag = "CoverCropSettings_Height",
            string rotateTag = "CoverCropSettings_Rotate",
            string scaleXTag = "CoverCropSettings_ScaleX",
            string scaleYTag = "CoverCropSettings_ScaleY")
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
