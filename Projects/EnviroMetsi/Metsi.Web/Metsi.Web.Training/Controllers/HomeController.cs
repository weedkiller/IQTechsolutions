using System.Collections.Generic;
using Metsi.Web.Training.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Metsi.Web.Training.Controllers
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
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CookieUse()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        /// <summary>
        /// Gets the under construction view
        /// </summary>
        /// <returns>The under construction View</returns>
        public IActionResult UnderConstruction()
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
            return SignOut("CookieTraining", "oidc");
        }

        public class MerchantSettingSkuSettingsModel
        {
            public int ProductAttributeSkuAliasColumnNr { get; set; }
            public string ProductAttributeSkuAliasColumnName { get; set; }

            public string ProductAttributeSkuTypeId { get; set; }
            public string ProductAttributeSkuTypeName { get; set; }

            public bool Visible { get; set; }
        }
    }
}
