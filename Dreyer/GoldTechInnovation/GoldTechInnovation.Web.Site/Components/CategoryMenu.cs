using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Grouping.Core.Context.Services;
using Products.Base.Entities;

namespace GoldTechInnovation.Web.Site.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly CategoryContext<Product> _categoryRepository;

        public CategoryMenu(CategoryContext<Product> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            // Get all categories and order them by name
            var categories = _categoryRepository.GetAllCategories().OrderBy(c => c.Name);

            // Return View with categories in it
            return View(categories);
        }
    }
}
