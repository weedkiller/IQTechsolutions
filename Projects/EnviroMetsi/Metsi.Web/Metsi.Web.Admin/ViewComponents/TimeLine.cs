using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Messaging.Core.Context.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.ViewComponents
{
    [ViewComponent(Name = "TimeLine")]
    public class TimeLine : ViewComponent
    {
        private TimeLineContext _service;

        public TimeLine(TimeLineContext service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            
            var list = _service.GetTimeLine(id);

            var groups = list
                .GroupBy(d => d.Created);

            return View(groups);
        }
    }
}
