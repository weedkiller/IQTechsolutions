using System;
using System.Threading.Tasks;
using Iqt.Base.Models;
using Iqt.Gallery.Entities;
using Iqt.Gallery.Interfaces;
using Iqt.Gallery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ReSharper disable Mvc.ViewNotResolved

namespace Iqt.Core.Controllers
{
    [Area("Gallery")]
    public class PhotoAlbumBaseController : Controller
    {
        /// <summary>
        /// The Photo Album Context Service for this controller
        /// </summary>
        protected readonly IPhotoAlbumService Service;

        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected application Photo Album Context Service</param>
        public PhotoAlbumBaseController(IPhotoAlbumService service)
        {
            Service = service;
        }

        /// <summary>
        /// Method used to set up the index page
        /// </summary>
        /// <returns>the index view</returns>
        [AllowAnonymous]
        public virtual async Task<IActionResult> Index(int? page, int size)
        {
            var serviceList = await Service.GetAll().ToListAsync();
            var model = new PhotoAlbumIndexModel(serviceList);
            return View(model);
        }

        /// <summary>
        /// Method used to set up the index page
        /// </summary>
        /// <returns>the index view</returns>
        public IActionResult List()
        {
            var model = Service.GetAll();
            return View(model);
        }

        /// <summary>
        /// This method sets up the detials view and model
        /// </summary>
        /// <param name="id">The identity of the album to be used</param>
        /// <returns>The chosen photoalbum</returns>
        [AllowAnonymous]
        public async Task<ActionResult> Details(string id)
        {
            var photoAlbum = await Service.GetAsync(id);
            return View(photoAlbum);
        }

        #region Create        

        /// <summary>
        /// The method used to get and setup the correct album details view
        /// GET: GET: Gallery/PhotoAlbums/Create
        /// </summary>
        /// <returns>The album details view</returns>
        public IActionResult Create()
        {
            var model = new PhotoAlbumAddEditModel()
            {
                PhotoAlbum = new PhotoAlbum()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PhotoAlbumAddEditModel model)
        {
            if (ModelState.IsValid)
            {
                await Service.AddAsync(model);
                return RedirectToAction("List");
            }

            return View(model);
        }

        #endregion

        #region Edit

        /// <summary>
        /// The method used to get the edit album view
        /// </summary>
        /// <param name="id">The id of the album to be updated</param>
        /// <returns>The edit product view with the relevant album</returns>
        public async Task<IActionResult> Edit(string id)
        {
            // Check to see if id is populated
            if (id == null)
            {
                return NotFound();
            }

            var album = await Service.GetAsync(id);

            if (album == null)
            {
                return NotFound();
            }
            var model = new PhotoAlbumAddEditModel(album);

            return View(model);
        }

        /// <summary>
        /// The method used to post to the update album to the server
        /// </summary>
        /// <param name="model">The model that the post is being updated from</param>
        /// <returns>The list view</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PhotoAlbumAddEditModel model)
        {
            if (ModelState.IsValid)
            {
                // Finds the correct blogpost
                await Service.UpdateAsync(model);

                // Redirect to the index page
                return RedirectToAction(nameof(List));

            }
            return View(model);
        }

        #endregion

        #region Delete

        /// <summary>
        /// The method used to setup the Delete Page
        /// </summary>
        /// <param name="id">The album that should be deleted</param>
        /// <returns>The page that shows the page to delete the album</returns>
        public async Task<IActionResult> Delete(string id)
        {
            var entity = await Service.GetAsync(id);

            var model = new ModalModel()
            {
                HeaderString = $"Are you sure you want to delete this Photo Album with id {entity.Id}",
                ControllerUrl = "/Gallery/PhotoAlbum/Delete",
                EntityId = entity.Id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// The method used to setup the Delete Page
        /// </summary>
        /// <param name="id">The album that should be deleted</param>
        /// <returns>The page that shows the page to delete the album</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                await Service.DeleteAsync(id);
                // Get a list of all the blog sub-categories in json format
                var y = Json(true);
                // Return the Json
                return y;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        #endregion

        #region Ajax Actions

        /// <summary>
        /// The ajax call to remove a image
        /// </summary>
        /// <param name="id">the identity of the image being removed</param>
        /// <returns>A json string to indicate whether the removal was successful or not</returns>
        [HttpPost]
        public ActionResult RemoveImageAjax(string id)
        {
            Service.DeleteImage(id);
            return Json("success");
        }

        #endregion
    }
}
