using System.Linq;
using System.Threading.Tasks;
using Iqt.Calender.Services;
using Iqt.Core.Controllers;
using Iqt.Gallery.Interfaces;
using Microsoft.AspNetCore.Mvc;
using KingdomLifestyleMinistries.Web.Site.Areas.Gallery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Gallery.Controllers
{
    /// <summary>
    /// The photo album controller of the application
    /// </summary>
    [Area("Gallery")]
    [Route("Gallery/[controller]/[action]")]
    public class PhotoAlbumController : PhotoAlbumBaseController
    {
        private EventContextService _eventService;

        /// <inheritdoc />
        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected application Photo Album Context Service</param>
        /// <param name="imageSettings">The image setting used to upload a image</param>
        public PhotoAlbumController(IPhotoAlbumService service, EventContextService eventService) : base(service)
        {
            _eventService = eventService;
        }

        public override async Task<IActionResult> Index(int? page, int size)
        {
            var model = new KlsmPhotoAlbumIndexModel(await Service.GetAll().ToListAsync(), size, page)
            {
                Events = _eventService.GetAll().ToList()
            };
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> EventAlbum(string id)
        {
            var model = await _eventService.GetAsync(id);
            return View(model);
        }
    }
}
