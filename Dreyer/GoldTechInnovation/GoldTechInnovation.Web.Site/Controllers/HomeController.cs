using GoldTechInnovation.Web.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoldTechInnovation.Web.Site.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

    }
}
