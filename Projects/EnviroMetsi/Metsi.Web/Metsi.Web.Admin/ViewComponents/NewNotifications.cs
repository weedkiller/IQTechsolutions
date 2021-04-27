using System.Collections.Generic;
using System.Threading.Tasks;
using Education.Base.Entities;
using Grouping.Core.Context.Services;
using Messaging.Base.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.ViewComponents
{
    [ViewComponent]
    public class NewNotifications : ViewComponent
    {
        private CategoryContext<Course> _service;

        public NewNotifications(CategoryContext<Course> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            return View(new List<Notification>());
        }
    }
}
