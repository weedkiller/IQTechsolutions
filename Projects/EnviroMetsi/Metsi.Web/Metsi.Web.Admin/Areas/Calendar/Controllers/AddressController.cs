using System.Linq;
using Calendar.Base.Entities;
using Iqt.Base.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Admin.Areas.Calendar.Controllers
{
    [Area("Calendar")]
    [Route("Calendar/[controller]/[action]")]
    public class AddressController : Controller
    {
        private DbContext _context;

        public AddressController(DbContext context)
        {
            _context = context;
        }

        public IActionResult GetRouteLocationAddress(string id)
        {
            var route = _context.Set<RouteLocation>().FirstOrDefault(c => c.Id == id);

            var address = _context.Set<Address<RouteLocation>>().Include(c => c.Location)
                .FirstOrDefault(c => c.EntityId == id);

            var model = new RouteLocationInfoWindowModel()
            {
                Lat = address.Location.Latitude,
                Lng = address.Location.Longitude,
                Name = route.Name,
                Id = route.Id
            };

            return new JsonResult(model);
        }
    }

    public class RouteLocationInfoWindowModel
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
