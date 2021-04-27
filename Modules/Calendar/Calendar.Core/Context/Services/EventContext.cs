using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Calendar.Core.Models;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Grouping.Base.Entities;
using Microsoft.EntityFrameworkCore;

// ReSharper disable PossibleNullReferenceException

namespace Calendar.Core.Context.Services
{
    /// <summary>
    /// The context service that manages service details in the database
    /// </summary>
    public class EventContext
    {
        #region Private Member

        private readonly DbContext _context;
        private readonly IFileFactory _fileFactory;

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// The default constructor  with injected parameters
        /// </summary>
        /// <param name="manager">The injected application repository manager</param>
        /// <param name="fileFactory">The injected file factory</param>
        /// <param name="featureService">The feature service context</param>
        public EventContext(DbContext context, IFileFactory fileFactory)
        {
            _fileFactory = fileFactory;
            _context = context;
        }

        #endregion

        public IQueryable<Event> GetAll()
        {
            return _context.Set<Event>().Include(c => c.Location).Include(c => c.Images)
                .Include(c => c.Contacts).Include(c => c.Categories);
        }

        public async Task<Event> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        #region Add Service

        /// <summary>
        /// Adds an service to the database asyncronously
        /// </summary>
        /// <param name="model">The model the service should be added from</param>
        /// <param name="imageSettings">The image settings used for uploading images</param>
        /// <returns> The employee that was added</returns>
        public async Task<Event> AddAsync(EventAddEditModel model)
        {
            _context.Set<Event>().Add(model.Entity);

            var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Event>(model.CoverUpload, null, "images/uploads/events/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
            
            if (model.ImagesUpload != null && model.ImagesUpload.Any())
            {
                foreach (var item in model.ImagesUpload)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<Event>(item, null, "images/uploads/events/images", ImageType.Image, new Point(0, 0), new Size(900, 500), model.Entity.Id);
                }
            }

            foreach (var item in model.AvailableCategories)
            {
                if (item.IsSelected)
                {
                    _context.Set<EntityCategory<Event>>()
                        .Add(new EntityCategory<Event>(model.Entity.Id, item.Identity));
                }
                else
                {
                    var existingEntity = _context.Set<EntityCategory<Event>>()
                        .Where(c => c.EntityId == model.Entity.Id).FirstOrDefault(c => c.CategoryId == item.Identity);
                    if (existingEntity != null)
                    {
                        _context.Set<EntityCategory<Event>>().Remove(existingEntity);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return model.Entity;
        }

        #endregion

        #region Update Event

        /// <summary>
        /// Update a specific service
        /// </summary>
        /// <param name="model">The model to be updated from</param>
        /// <param name="imageSettings">The image settings used to upload the files</param>
        /// <returns>The updated service</returns>
        public async Task<Event> UpdateAsync(EventAddEditModel model)
        {
            var eventEntity = await GetAll().Include(c => c.Location).FirstOrDefaultAsync(c => c.Id == model.Entity.Id);

            _context.Entry(eventEntity).CurrentValues.SetValues(model.Entity);

            var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Event>(model.CoverUpload, eventEntity.GetImage()?.Id, "images/uploads/services/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUpload != null && model.ImagesUpload.Any())
            {
                foreach (var item in model.ImagesUpload)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<Event>(item, null, "images/uploads/services/images", ImageType.Image, new Point(0, 0), new Size(900, 500), model.Entity.Id, true);
                }
            }

            foreach (var item in model.AvailableCategories)
            {
                var existingEntity = _context.Set<EntityCategory<Event>>()
                    .Where(c => c.EntityId == model.Entity.Id).FirstOrDefault(c => c.CategoryId == item.Identity);
                if (item.IsSelected)
                {
                    if (existingEntity == null)
                    {
                        _context.Set<EntityCategory<Event>>().Add(new EntityCategory<Event>(eventEntity.Id, item.Identity));
                    }
                }
                else
                {
                    if (existingEntity != null)
                    {
                        _context.Set<EntityCategory<Event>>().Remove(existingEntity);
                    }
                }
                
            }
            _context.Set<Event>().Update(eventEntity);
            await _context.SaveChangesAsync();

            return model.Entity;
        }

        #endregion

        #region Delete Service

        /// <inheritdoc />
        /// <summary>
        /// Deletes a specific Service
        /// </summary>
        /// <param name="id">The identity of the service to be deleted</param>
        /// <returns>The deleted blog post</returns>
        public async Task<Event> DeleteAsync(string id)
        {
            // Gets the product to be deleted
            var blogPost = await GetAsync(id);

            foreach (var photoAlbum in blogPost.Images.ToList())
                {
                   await _fileFactory.DeleteImageAndRemoveFormDbAsync(photoAlbum);
                }

            // deletes the product from the database
            try
            {
                _context.Set<Event>().Remove(blogPost);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            await _context.SaveChangesAsync();

            return blogPost;
        }

        #endregion

        #region Children

        #region Category

        /// <summary>
        /// Get an enumerated list of all the service categories
        /// </summary>
        /// <returns>An enumerated list of all the blog categories</returns>
        public IEnumerable<Category<Event>> GetCategories()
        {
            return _context.Set<Category<Event>>().Include(p => p.EntityCollection)
                .Include(p => p.SubCategories).Where(c => c.ParentCategoryId == null);
        }

        /// <summary>
        /// Get an enumerated list of all the service sub-categories
        /// </summary>
        /// <returns>An enumerated list of all the service sub-categories</returns>
        public IEnumerable<Category<Event>> GetSubCategories(string parentId)
        {
            return _context.Set<Category<Event>>().Include(p => p.EntityCollection)
                .Include(c => c.Images).Include(c => c.SubCategories).Where(c => c.ParentCategoryId == parentId);
        }

        /// <summary>
        /// Gets a specific service Category
        /// </summary>
        /// <param name="id">identity of the category</param>
        /// <returns>the specific category</returns>
        public async Task<Category<Event>> GetCategoryAsync(string id)
        {
            return await _context.Set<Category<Event>>().Include(p => p.EntityCollection)
                .Include(c => c.Images).Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds a specific service category
        /// </summary>
        /// <param name="model">The model to be added from</param>
        /// <param name="imageSettings">The settings used to upload images</param>
        /// <returns>The product service that was added</returns>
        //      public async Task<Category<Event>> AddCategory(CategoryAddEditModel<Category<Event>> model, ImageSettings imageSettings)
        //      {
        //  //        if (model.CoverUpload != null)
        //  //            model.Entity.CoverImage = await _fileFactory.UploadImage(model.CoverUpload, imageSettings);
        //
        //          // Add the product to the database
        //          Manager.Repository<Category<Event>>().Add(model.Entity);
        //          await Manager.SaveAsync();
        //
        //          return model.Entity;
        //      }

        /// <summary>
        /// Update a specific service category
        /// </summary>
        /// <param name="model">The model to be updated from</param>
        /// <param name="imageSettings">The image settings to used to upload images</param>
        /// <returns>The service category that was updated</returns>
        //   public async Task<Category<Event>> UpdateCategoryAsync(CategoryAddEditModel<Event> model, ImageSettings imageSettings)
        //   {
        //   //    var category = await GetCategoryAsync(model.Entity.Id);
        //   //
        //   //    category.Category.Name = model.Entity.Name;
        //   //    category.Category.Description = model.Entity.Description;
        //   //
        //   //    if (model.CoverUpload != null)
        //   //    {
        //   //        if (category.Category.CoverImage != null)
        //   //        {
        //   //            _fileFactory.DeleteFile(category.Category.CoverImage.FolderPath, category.Category.CoverImage.FileName);
        //   //            Manager.Repository<FileBase>().Delete(category.Category.CoverImage);
        //   //            await Manager.SaveAsync();
        //   //        }
        //   //
        //   // //       model.Entity.CoverImage = await _fileFactory.UploadImage(model.CoverUpload, imageSettings);
        //   //    }
        //   //
        //   //    // Add the product to the database
        //   //    Manager.Repository<Category<Event>>().Update(category);
        //   //    await Manager.SaveAsync();
        //   //
        //   //    return category;
        //   }

        /// <summary>
        /// Update a specific product
        /// </summary>
        /// <param name="id">The identity of the category that should be deleted</param>
        /// <returns>The categoty that was updated</returns>
        //   public async Task<EventCategory> DeleteCategoryAsync(string id)
        //   {
        //       // Gets the product to be deleted
        //       var category = await GetCategoryAsync(id);
        //
        //       // Check to see if there is a coverimage that should be deleted
        //       if (category.SubCategories != null && category.SubCategories.Any())
        //       {
        //           // iterate through the packsizes
        //           foreach (var sub in category.SubCategories)
        //           {
        //               await DeleteCategoryAsync(sub.Id);
        //           }
        //           category.SubCategories = null;
        //       }
        //
        //       // Check to see if there is a coverimage that should be deleted
        //       if (category.CoverImage != null)
        //       {
        //           // Delete the cover image
        //           Manager.Repository<FileBase>().Delete(category.CoverImage);
        //           _fileFactory.DeleteFile(category.CoverImage);
        //       }
        //
        //       // deletes the product from the database
        //       Manager.Repository<EventCategory>().Delete(category);
        //       await Manager.SaveAsync();
        //
        //       return category;
        //   }

        #endregion

        #region Event Registration

        public IQueryable<EventRegistration> GetEventRegistrations(string eventId)
        {
            return _context.Set<EventRegistration>().Where(c => c.EventId == eventId);
        }

        public async Task<EventRegistration> GetEventRegistration(string id)
        {
            return await _context.Set<EventRegistration>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<EventRegistration> AddEventRegistrationAsync(EventRegistrationAddEditModel model)
        {
            var registration = new EventRegistration()
            {
                Title = model.Title,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ContactNr = model.ContactNr,
                Attendees = model.Attendees,
                EmailAddress = model.EmailAddress,
                Notes = model.Notes,
                EventId = model.EventId

            };
            //foreach (var item in model.SelectedEventDates)
            //{
            //    registration.EventDays.Add(new EventDay()
            //    {
            //        DateTime = item.Date,
            //        StartTime = item.TimeOfDay
            //    });
            //}

            _context.Set<EventRegistration>().Add(registration);
            await _context.SaveChangesAsync();

            return registration;
        }

        public async Task<EventRegistration> RemoveEventRegistration(string id)
        {
            var registration = await GetEventRegistration(id);
            _context.Set<EventRegistration>().Remove(registration);
            await _context.SaveChangesAsync();
            return registration;
        }

        #endregion

        #endregion
        
        /// <summary>
        /// Removes a single image
        /// </summary>
        /// <param name="id">The identity of the image that must be removed</param>
        public void RemoveImage(string id)
        {
            // Get the file to be deleted
            var file = _context.Set<ImageFile<Event>>().FirstOrDefault(c => c.Id == id);
            try
            {
                _context.Set<ImageFile<Event>>().Remove(file);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
