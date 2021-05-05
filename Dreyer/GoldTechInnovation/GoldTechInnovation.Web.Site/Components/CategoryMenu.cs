using GoldTechInnovation.Web.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldTechInnovation.Web.Site.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            // Get all categories and order them by name
            var categories = _categoryRepository.GetAllCategories.OrderBy(c => c.Name);

            // Return View with categories in it
            return View(categories);
        }
    }
}
