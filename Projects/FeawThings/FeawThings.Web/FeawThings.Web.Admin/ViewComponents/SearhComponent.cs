using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FeawThings.Web.Admin.ViewComponents
{
    [ViewComponent]
    public class SearhComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
