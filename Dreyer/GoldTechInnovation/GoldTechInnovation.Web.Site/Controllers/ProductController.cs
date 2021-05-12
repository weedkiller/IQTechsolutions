using GoldTechInnovation.Web.Site.Models;
using GoldTechInnovation.Web.Site.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GoldTechInnovation.Web.Site.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Product> products;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.GetAllProduct.OrderBy(c => c.Id);
                currentCategory = "All Product";
            }
            else
            {
                products = _productRepository.GetAllProduct.Where(c => c.Category.Name == category);
                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.Name == category)?.Name;
            }

            return View(new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory

            });
        }

        public IActionResult Details(string id)
        {
            var product = _productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        
    }
}
