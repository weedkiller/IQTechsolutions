using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FeawThings.Web.Clients.ViewComponents
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
