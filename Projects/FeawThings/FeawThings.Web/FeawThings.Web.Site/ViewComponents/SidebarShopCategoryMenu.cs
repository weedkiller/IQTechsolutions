using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Base.Api.Services;

namespace FeawThings.Web.Site.ViewComponents
{
    [ViewComponent]
    public class SidebarShopCategoryMenu : ViewComponent
    {
        private readonly ProductCategoriesApiService _service;

        public SidebarShopCategoryMenu(ProductCategoriesApiService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _service.GetAllCategoriesAsync();
            return View(model.ServerResponse);
        }
    }
}
