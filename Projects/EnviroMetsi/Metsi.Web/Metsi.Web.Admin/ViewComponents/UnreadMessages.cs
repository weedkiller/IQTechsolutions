using System.Collections.Generic;
using System.Threading.Tasks;
using Education.Base.Entities;
using Grouping.Core.Context.Services;
using Grouping.Core.Models;
using Messaging.Base.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.ViewComponents
{
    [ViewComponent]
    public class UnreadMessages : ViewComponent
    {
        private CategoryContext<Course> _service;

        public UnreadMessages(CategoryContext<Course> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            return View(new List<Message>());
        }
    }
}
