using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Calendar.Base.Entities;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Microsoft.EntityFrameworkCore;
using Services.Base.Entities;
using Services.Core.Models;

namespace Services.Core.Context.Services
{
    public class ServiceContext
    {
        private readonly DbContext _context;
        private readonly IFileFactory _fileFactory;

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context">The injected database context</param>
        /// <param name="fileFactory">The injected file factory</param>
        public ServiceContext(DbContext context, IFileFactory fileFactory)
        {
            _context = context;
            _fileFactory = fileFactory;
        }

        #endregion

        /// <summary>
        /// Get an <see cref="IQueryable" /> list of all the Service entries
        /// </summary>
        /// <returns>An <see cref="IQueryable" /> list of all the Service entries</returns>
        public IQueryable<Service> GetAll()
        {
            try
            {
                var serviceList = _context.Set<Service>()
                    .Include(b => b.Images)
                    .Include(c => c.Categories)
                    .ThenInclude(c => c.Category);

                return serviceList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Get an <see cref="IQueryable" /> list of all the Service entries filtered by category id
        /// </summary>
        /// <param name="categoryId">The identity of the category to filter the service list by</param>
        /// <returns>An <see cref="IQueryable" /> list of all the Service entries</returns>
        public IEnumerable<Service> GetByCategory(string categoryId)
        {
            var result = from service in _context.Set<Service>().Include(c => c.Categories).ToList()
                from category in service.Categories
                where category.CategoryId == categoryId
                select service;

            return result.Distinct().ToList();

        }

        /// <summary>
        /// Gets a specific service
        /// </summary>
        /// <param name="id">The identity of the service to retrieve</param>
        /// <returns>A specific service</returns>
        public async Task<Service> GetEntityAsync(string id)
        {
            try
            {
                var service = await _context.Set<Service>().Include(b => b.Images).Include(c => c.IncludedServices).ThenInclude(c => c.Entity)
                    .Include(c => c.Combos).ThenInclude(c => c.ComboRecipyCategory)
                    .Include(c => c.Categories).ThenInclude(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);

                return service;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Add or updates a service to the database
        /// </summary>
        /// <param name="model">The model of the service to be updated/added</param>
        /// <returns>The updated/added service</returns>
        public async Task<Service> AddOrUpdateAsync(ServiceAddEditModel model)
        {
            var existingService = await _context.Set<Service>().FirstOrDefaultAsync(c => c.Id == model.Entity.Id);

            

            if (existingService != null)
            {
                var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Service>(model.CoverUpload, existingService.GetImage()?.Id, "images/uploads/services/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
                var banner = await _fileFactory.UploadImageAndSaveToDbAsync<Service>(model.BannerUpload, existingService.GetImage(ImageType.Banner)?.Id, "images/uploads/services/banners", ImageType.Banner, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);

                foreach (var item in model.AvailableCategories)
                {
                    await ProcessAvailableCategories(existingService, item);
                }

                _context.Entry(existingService).CurrentValues.SetValues(model.Entity);
            }
            else
            {
                _context.Set<Service>().Add(model.Entity);

                var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Service>(model.CoverUpload, null, "images/uploads/services/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
                var banner = await _fileFactory.UploadImageAndSaveToDbAsync<Service>(model.BannerUpload, null, "images/uploads/services/banners", ImageType.Banner, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);

                foreach (var item in model.AvailableCategories)
                {
                    await ProcessAvailableCategories(model.Entity, item);
                }
            }


            if (model.ImagesUpload != null && model.ImagesUpload.Any())
            {
                foreach (var item in model.ImagesUpload)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<Service>(item, null, "images/uploads/services/images", ImageType.Image, new Point(0, 0), new Size(870, 260), model.Entity.Id, true);
                }
            }

            await _context.SaveChangesAsync();
            return existingService;
        }

        private async Task ProcessAvailableCategories(Service parent, CheckBoxSelectionModel<Category<Service>> item)
        {
            if (item.HasChildSelection)
            {
                foreach (var ss in item.ChildSelection)
                {
                    await ProcessAvailableCategories(parent, ss);
                }
            }

            var result = await _context.Set<EntityCategory<Service>>().Where(c => c.CategoryId == item.Identity)
                .FirstOrDefaultAsync(c => c.EntityId == parent.Id);

            if (item.IsSelected && result == null)
            {
                _context.Set<EntityCategory<Service>>().Add(new EntityCategory<Service>(parent.Id, item.Identity));
            }
            else if (!item.IsSelected && result != null)
            {
                _context.Set<EntityCategory<Service>>().Remove(result);
            }
        }

        /// <summary>
        /// Removes a specific entity from the database
        /// </summary>
        /// <param name="id">The identity of the service to be removed</param>
        /// <returns>The removed service</returns>
        public async Task<Service> DeleteAsync(string id)
        {
            // Gets the product to be deleted
            var service = await GetEntityAsync(id);

            foreach (var item in service.Images.ToList())
            {
                await _fileFactory.DeleteImageAndRemoveFormDbAsync(item);
            }
            foreach (var item in service.Categories.ToList())
            {
                _context.Set<EntityCategory<Service>>().Remove(item);
            }

            // deletes the product from the database
            _context.Set<Service>().Remove(service);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }

            return service;
        }

        /// <summary>
        /// Removes the entity category relationships associated with the service from the database
        /// </summary>
        /// <param name="category">The relationship to be removed</param>
        public async Task RemoveCategory(EntityCategory<Service> category)
        {
            _context.Set<EntityCategory<Service>>().Remove(category);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new entity category relationship to the database
        /// </summary>
        /// <param name="category">The entity category relationship to add</param>
        public async Task AddCategory(EntityCategory<Service> category)
        {
            _context.Set<EntityCategory<Service>>().Add(category);
            await _context.SaveChangesAsync();
        }

        #region Included Services

        /// <summary>
        /// Gets a specific included service for a service from the database
        /// </summary>
        /// <param name="serviceId">The identity of the service that is included</param>
        /// <param name="parentServiceId">The identity of the parent service that owns this included service</param>
        /// <returns>A specific included service</returns>
        public async Task<IncludedService<Service>> GetIncludedAsync(string serviceId, string parentServiceId)
        {
            return await _context.Set<IncludedService<Service>>().Include(c => c.Service).Include(c => c.Entity).Where(c => c.EntityId == parentServiceId).FirstOrDefaultAsync(c => c.ServiceId == serviceId);
        }

        /// <summary>
        /// Adds a included service relationship to the database
        /// </summary>
        /// <param name="included">The included service relationship to be added</param>
        /// <returns>The added included service relationship</returns>
        public async Task<IncludedService<Service>> AddUpdateIncludedService(IncludedService<Service> included)
        {
            var existing = await GetIncludedAsync(included.ServiceId, included.EntityId);

            if (existing == null)
            {
                _context.Set<IncludedService<Service>>().Add(included);
            }
            else
            {
                existing.Qty = included.Qty;
                _context.Set<IncludedService<Service>>().Update(existing);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return included;
        }

        /// <summary>
        /// Removes a specific included service relationship from the database
        /// </summary>
        /// <param name="serviceId">The identity of the service that is included</param>
        /// <param name="parentServiceId">The identity of the parent service that owns this included service</param>
        public async Task RemoveIncludedService(string serviceId, string parentServiceId)
        {
            var service = await GetIncludedAsync(serviceId, parentServiceId);
            _context.Set<IncludedService<Service>>().Remove(service);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        #region Optional Services

        /// <summary>
        /// Gets a specific optional service for a service from the database
        /// </summary>
        /// <param name="serviceId">The identity of the service that is optionally included</param>
        /// <param name="parentServiceId">The identity of the parent service that owns this optionaly included service</param>
        /// <returns>A specific optionally included service</returns>
        public async Task<OptionalService<Service>> GetOptionalAsync(string serviceId, string parentServiceId)
        {
            return await _context.Set<OptionalService<Service>>().Include(c => c.Service).Include(c => c.Entity).Where(c => c.EntityId == parentServiceId).FirstOrDefaultAsync(c => c.ServiceId == serviceId);
        }

        /// <summary>
        /// Adds a optional service relationship to the database
        /// </summary>
        /// <param name="optional">The optional service relationship to be added</param>
        /// <returns>The added optional service relationship</returns>
        public async Task<OptionalService<Service>> AddUpdateOptionalService(OptionalService<Service> optional)
        {
            var existing = await GetOptionalAsync(optional.ServiceId, optional.EntityId);

            if (existing == null)
            {
                _context.Set<OptionalService<Service>>().Add(optional);
            }
            else
            {
                existing.Qty = optional.Qty;
                _context.Set<OptionalService<Service>>().Update(existing);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return optional;
        }

        /// <summary>
        /// Removes a specific optional service relationship from the database
        /// </summary>
        /// <param name="serviceId">The identity of the service that is optionally included</param>
        /// <param name="parentServiceId">The identity of the parent service that owns this optionally included service</param>
        public async Task RemoveOptionalService(string serviceId, string parentServiceId)
        {
            var service = await GetOptionalAsync(serviceId, parentServiceId);
            _context.Set<OptionalService<Service>>().Remove(service);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        #endregion

        #region ComboCategories

        /// <summary>
        /// Gets a specific optional service for a service from the database
        /// </summary>
        /// <param name="categoryId">The identity of the category that is included</param>
        /// <param name="serviceId">The identity of the parent service that owns this combo category</param>
        /// <returns>A specific combo category</returns>
        public async Task<ComboCategory<Service>> GetComboCategoryAsync(string categoryId, string serviceId)
        {
            return await _context.Set<ComboCategory<Service>>()
                .Include(c => c.ComboRecipyCategory).Include(c => c.ComboItem)
                .Include(c => c.Exclusions).ThenInclude(c => c.Exclusion)
                .Where(c => c.ComboItemId == serviceId).FirstOrDefaultAsync(c => c.ComboRecipyCategoryId == categoryId);
        }

        /// <summary>
        /// Adds a new combo category relationship to the database
        /// </summary>
        /// <param name="model">The model of the combo category to be added</param>
        /// <returns>The added combo category</returns>
        public async Task<ComboCategory<Service>> AddUpdateComboCategory(ComboCategory<Service> model)
        {
            var service = await GetEntityAsync(model.ComboItemId);

            var existing = await GetComboCategoryAsync(service.Id, model.ComboRecipyCategoryId);
            if (existing == null)
            {
                _context.Set<ComboCategory<Service>>().Add(model);
            }
            else
            {
                existing.Qty = model.Qty;
                _context.Set<ComboCategory<Service>>().Add(existing);
            }

            

            await _context.SaveChangesAsync();
            return model;
        }

        /// <summary>
        /// Removes a specific combo category relationship from the database
        /// </summary>
        /// <param name="id">The identity of the combo category to be removed</param>
        public async Task RemoveCombo(string serviceId, string categoryId)
        {
            var category = await _context.Set<ComboCategory<Service>>().Where(c => c.ComboItemId == serviceId).FirstOrDefaultAsync(c => c.ComboRecipyCategoryId == categoryId);
            _context.Set<ComboCategory<Service>>().Remove(category);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Categories

        /// <summary>
        /// Gets all categories from the database
        /// </summary>
        /// <param name="id">The identity of the parent category if any</param>
        /// <returns>A list of categories</returns>
        public IQueryable<Category<Service>> GetAllCategories()
        {
            var p = _context.Set<Category<Service>>();
            return p;
        }

        /// <summary>
        /// Gets all the parent categories from the database if id is null
        /// else returns all the sub categories of the category with that id
        /// </summary>
        /// <param name="id">The identity of the parent category if any</param>
        /// <returns>A list of categories</returns>
        public IQueryable<Category<Service>> GetParentAllCategories(string id = null)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return GetAllCategories().Where(c => c.ParentCategoryId == id);
            }
            var p = GetAllCategories().Where(c => c.ParentCategoryId == null);
            return p;
        }

        /// <summary>
        /// Gets a specific service Category
        /// </summary>
        /// <param name="id">identity of the category</param>
        /// <returns>the specific category</returns>
        public async Task<EntityCategory<Service>> GetCategoryAsync(string serviceId, string categoryId)
        {
            return await _context.Set<EntityCategory<Service>>().Include(c => c.Category).ThenInclude(c => c.Images)
                .Where(c => c.EntityId == serviceId).FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        #endregion

        #region Combo Category Exclusions

        public async Task<ComboExclusions<Service>> AddExclusion(string categoryId, string serviceId)
        {
            var exclusion = new ComboExclusions<Service>()
            {
                ComboCategoryId = categoryId,
                ExclusionId = serviceId
            };

            _context.Set<ComboExclusions<Service>>().Add(exclusion);
            await _context.SaveChangesAsync();

            return exclusion;
        }

        public async Task<ComboExclusions<Service>> RemoveExclusion(string categoryId, string serviceId)
        {
            var exclusion = await _context.Set<ComboExclusions<Service>>().Where(c => c.ComboCategoryId == categoryId)
                .FirstOrDefaultAsync(c => c.ExclusionId == serviceId);

            _context.Set<ComboExclusions<Service>>().Remove(exclusion);
            await _context.SaveChangesAsync();

            return exclusion;
        }

        #endregion

        #region Service Tasks

        /// <summary>
        /// Gets a specific optional service for a service from the database
        /// </summary>
        /// <param name="categoryId">The identity of the category that is included</param>
        /// <param name="serviceId">The identity of the parent service that owns this combo category</param>
        /// <returns>A specific combo category</returns>
        public async Task<EntityTask<Service>> GetServiceTaskAsync(string taskId, string serviceId)
        {
            return await _context.Set<EntityTask<Service>>()
                .Include(c => c.Task).Include(c => c.Entity)
                .Where(c => c.EntityId == serviceId).FirstOrDefaultAsync(c => c.TaskId == taskId);
        }

        public async Task<EntityTask<Service>> RemoveTaskAsync(string taskId, string serviceId)
        {
            var newTask = await _context.Set<EntityTask<Service>>().Where(c => c.TaskId == taskId)
                .FirstOrDefaultAsync(c => c.EntityId == serviceId);
            _context.Set<EntityTask<Service>>().Add(newTask);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return newTask;
        }


        #endregion

        /// <summary>
        /// Removes a single image
        /// </summary>
        /// <param name="id">The identity of the image that must be removed</param>
        public void RemoveImage(string id)
        {
            // Get the file to be deleted
            var file = _context.Set<ImageFile<Service>>().FirstOrDefault(c => c.Id == id);
           _fileFactory.DeleteImageAndRemoveFormDbAsync(file);
        }
    }
}
