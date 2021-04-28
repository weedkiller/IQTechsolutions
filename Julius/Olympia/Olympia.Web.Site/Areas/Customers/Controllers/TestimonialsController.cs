using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Olympia.Web.Site.Areas.Customers.Controllers
{
    [Area("Customers")]
    [Route("Customers/[controller]/[action]")]
    public class TestimonialsController : TestimonialsBaseController
    {
        public TestimonialsController(DbContext context) : base(context)
        {
        }
    }
}
