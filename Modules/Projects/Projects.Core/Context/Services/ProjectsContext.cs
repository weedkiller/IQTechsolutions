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
using Iqt.Calender.Models;
using Microsoft.EntityFrameworkCore;
using Projects.Base.Entities;
using Projects.Core.Models;

namespace Projects.Core.Context.Services
{
    public class ProjectsContext
    {
        private readonly IFileFactory _fileFactory;
        private readonly DbContext _context;

        public ProjectsContext(IFileFactory fileFactory, DbContext context)
        {
            _fileFactory = fileFactory;
            _context = context;
        }

        public IQueryable<Project> GetAll()
        {
            return _context.Set<Project>().Include(c => c.Images).Include(c => c.Categories);
        }

        public async Task<Project> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds a specific product
        /// </summary>
        /// <param name="model">The model to be added from</param>
        /// <returns>The product that was added</returns>
        public async Task<Project> AddAsync(ProjectAddEditModel model)
        {
            _context.Set<Project>().Add(model.Entity);

            foreach (var item in model.AvailableCategories)
            {
                await ProcessAvailableCategories(model.Entity, item);
            }

            var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(model.CoverUpload, null, "images/uploads/projects/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
            var banner = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(model.IconUpload, null, "images/uploads/projects/icons", ImageType.Icon, new Point(Convert.ToInt16(model.IconCropSettings.X), Convert.ToInt16(model.IconCropSettings.Y)), new Size(Convert.ToInt16(model.IconCropSettings.Width), Convert.ToInt16(model.IconCropSettings.Height)), model.Entity.Id);
            var slider = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(model.BannerUpload, null, "images/uploads/projects/banners", ImageType.Banner, new Point(Convert.ToInt16(model.BannerCropSettings.X), Convert.ToInt16(model.BannerCropSettings.Y)), new Size(Convert.ToInt16(model.BannerCropSettings.Width), Convert.ToInt16(model.BannerCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUpload != null && model.ImagesUpload.Any())
            {
                foreach (var item in model.ImagesUpload)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(item, null, "images/uploads/projects/images", ImageType.Image, new Point(0, 0), new Size(900, 500), model.Entity.Id, true);
                }
            }

            if (model.SliderImagesUpload != null && model.SliderImagesUpload.Any())
            {
                foreach (var item in model.SliderImagesUpload)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(item, null, "images/uploads/projects/images", ImageType.Slider, new Point(0, 0), new Size(550, 370), model.Entity.Id, true);
                }
            }

            if (model.MockupsUpload != null && model.MockupsUpload.Any())
            {
                foreach (var item in model.MockupsUpload)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(item, null, "images/uploads/projects/images", ImageType.Mockup, new Point(0, 0), new Size(1920, 1080), model.Entity.Id, true);
                }
            }

            foreach (var item in model.AvailableCategories)
            {
                if (item.IsSelected)
                {
                    _context.Set<EntityCategory<Project>>().Add(new EntityCategory<Project>(model.Entity.Id, item.Identity));
                }
                else
                {
                    var existingEntity = _context.Set<EntityCategory<Project>>().Where(c => c.EntityId == model.Entity.Id).FirstOrDefault(c => c.CategoryId == item.Identity);
                    if (existingEntity != null)
                    {
                        _context.Set<EntityCategory<Project>>().Remove(existingEntity);
                    }
                }
                
            }
            await _context.SaveChangesAsync();
            return model.Entity;
        }

        /// <summary>
        /// Update a specific product
        /// </summary>
        /// <param name="model">The model to be updated from</param>
        /// <returns>The product that was updated</returns>
        public async Task<Project> UpdateAsync(ProjectAddEditModel model)
        {
            var project = _context.Set<Project>().Include(c => c.Images).Include(c => c.Categories).FirstOrDefault(c => c.Id == model.Entity.Id);
            

            foreach (var item in model.AvailableCategories)
            {
                await ProcessAvailableCategories(model.Entity, item);
            }

            var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(model.CoverUpload, project.GetImage()?.Id, "images/uploads/projects/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
            var banner = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(model.IconUpload, project.GetImage(ImageType.Icon)?.Id, "images/uploads/projects/icons", ImageType.Icon, new Point(Convert.ToInt16(model.IconCropSettings.X), Convert.ToInt16(model.IconCropSettings.Y)), new Size(Convert.ToInt16(model.IconCropSettings.Width), Convert.ToInt16(model.IconCropSettings.Height)), model.Entity.Id);
            var slider = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(model.BannerUpload, project.GetImage(ImageType.Banner)?.Id, "images/uploads/projects/banners", ImageType.Banner, new Point(Convert.ToInt16(model.BannerCropSettings.X), Convert.ToInt16(model.BannerCropSettings.Y)), new Size(Convert.ToInt16(model.BannerCropSettings.Width), Convert.ToInt16(model.BannerCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUpload != null && model.ImagesUpload.Any())
            {
                foreach (var item in model.ImagesUpload)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(item, null, "images/uploads/projects/images", ImageType.Image, new Point(0, 0), new Size(900, 500), model.Entity.Id, true);
                }
            }

            if (model.SliderImagesUpload != null && model.SliderImagesUpload.Any())
            {
                foreach (var item in model.SliderImagesUpload)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(item, null, "images/uploads/projects/images", ImageType.Slider, new Point(0, 0), new Size(550, 370), model.Entity.Id, true);
                }
            }

            if (model.MockupsUpload != null && model.MockupsUpload.Any())
            {
                foreach (var item in model.MockupsUpload)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<Project>(item, null, "images/uploads/projects/images", ImageType.Mockup, new Point(0, 0), new Size(1920, 1080), model.Entity.Id, true);
                }
            }

            _context.Entry(project).CurrentValues.SetValues(model.Entity);
         //   _context.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a specific product
        /// </summary>
        /// <param name="id">The identity of project to be deleted</param>
        /// <returns>The product that was updated</returns>
        public async Task<Project> DeleteAsync(string id)
        {
            // Gets the product to be deleted
            var product = await _context.Set<Project>().Include(c => c.Images).FirstOrDefaultAsync(c => c.Id == id);

            foreach (var item in product.Images.ToList())
            {
                await _fileFactory.DeleteImageAndRemoveFormDbAsync(item);
            }

            _context.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Project> GetNextAsync(Project current)
        {
            var entityList = await _context.Set<Project>().Where(c => c.Featured).ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index < entityList.Count - 1 ? entityList[index + 1] : null;
        }

        public async Task<Project> GetPreviousAsync(Project current)
        {
            var entityList = await _context.Set<Project>().Where(c => c.Featured).ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index < entityList.Count - 1 ? entityList[index + 1] : null;
        }

        #region Children

        #region Tasks

        public async Task<EntityTask<Project>> AddTaskAsync(TaskModel model)
        {
            var newTask = new EntityTask<Project>()
            {
                EntityId = model.ParentId,
                Task = new RecurringTask()
                {
                    Name = model.Heading,
                    Description = model.Description
                }
            };
            _context.Set<EntityTask<Project>>().Add(newTask);
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

        #region Categories

        /// <summary>
        /// Get an enumerated list of all the product categories
        /// </summary>
        /// <returns>An list of all the product categories</returns>
        public IEnumerable<EntityCategory<Project>> GetCategories()
        {
            var categories = _context.Set<EntityCategory<Project>>().Include(c => c.Category);
            return categories;
        }

        /// <summary>
        /// Get an enumerated list of all the product categories
        /// </summary>
        /// <returns>An list of all the product categories</returns>
        public IEnumerable<EntityCategory<Project>> GetSubCategories(string id = "")
        {
            var subcategories = _context.Set<EntityCategory<Project>>();
            if (!string.IsNullOrEmpty(id))
            {
                return subcategories;
            }
            return subcategories;
        }

        private async Task ProcessAvailableCategories(Project parent, CheckBoxSelectionModel<Category<Project>> item)
        {
            if (item.HasChildSelection)
            {
                foreach (var ss in item.ChildSelection)
                {
                    await ProcessAvailableCategories(parent, ss);
                }
            }

            var result = await _context.Set<EntityCategory<Project>>().Where(c => c.CategoryId == item.Identity)
                .FirstOrDefaultAsync(c => c.EntityId == parent.Id);

            if (item.IsSelected && result == null)
            {
                _context.Set<EntityCategory<Project>>().Add(new EntityCategory<Project>(parent.Id, item.Identity));
            }
            else if (!item.IsSelected && result != null)
            {
                _context.Set<EntityCategory<Project>>().Remove(result);
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// Removes Image from database
        /// </summary>
        /// <param name="id"></param>
        public async Task RemoveImage(string id)
        {
            var addintional = _context.Set<ImageFile<Project>>().FirstOrDefault(c => c.Id == id);
            await _fileFactory.DeleteImageAndRemoveFormDbAsync<Project>(addintional);
        }
    }
}
