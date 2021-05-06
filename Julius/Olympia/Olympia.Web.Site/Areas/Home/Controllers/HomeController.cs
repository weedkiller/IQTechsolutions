using Microsoft.AspNetCore.Mvc;
using Feedback.Core.Context.Services;
using Feedback.Core.Controllers;
using GoogleReCaptcha.V3.Interface;
using Identity.Base.Entities;
using Olympia.Web.Email;


namespace Olympia.Web.Site.Areas.Home.Controllers

{
    [Area("Home")]
    [Route("Home/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();



        }

      
    }

  

}






