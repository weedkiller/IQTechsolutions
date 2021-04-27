using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FeawThings.Web.Site.ViewComponents
{
    [ViewComponent]
    public class ShoppingCartMenu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
