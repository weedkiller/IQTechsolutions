using Iqt.Calender.Entities;
using Iqt.Social.Controllers;
using Iqt.Social.Services;
using Microsoft.AspNetCore.Mvc;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Events.Controllers
{

    [Area("Events")]
    [Route("Events/[controller]/[action]")]
    public class ContactsController : ContactBaseController<Event>
    {
        public ContactsController(ContactsContextService<Event> service) : base(service)
        {
        }
    }
}