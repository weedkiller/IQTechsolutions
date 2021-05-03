using Microsoft.AspNetCore.Mvc;
using Feedback.Core.Context.Services;
using Feedback.Core.Controllers;
using GoogleReCaptcha.V3.Interface;
using Identity.Base.Entities;
using Olympia.Web.Email;


namespace Olympia.Web.Site.Areas.ImageModels.Controllers
{ 

     [Area("Home")]
    [Route("Home/[controller]/[action]")]

    public class ImageModelsController : Controller


    {
        public class UserProfileViewModel
        {
            public string UserName { get; set; }
            //public IFormFile UploadedImage { get; set; }
            public string ImageUrl { get; set; }
           
           
        }


        public IActionResult Index()
        {
            return View();
        }

    }

}
