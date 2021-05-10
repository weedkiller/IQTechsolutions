using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Grouping.Base.Entities;
using Grouping.Core.Models;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.EntityFrameworkCore;

namespace Grouping.Core.Context.Services
{
    /// <summary>
    /// The context service that manages <see cref="Category{T}"/> in the database
    /// </summary>
    public class CategoryContext<T> where T : IEntityBase, new()
    {
        #region Private Members

        private readonly IApplicationConfiguration _configuration;
        private readonly IFileFactory _fileFactory;
        private readonly DbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Foreign Db Context Constructor
        /// </summary>
        /// <param name="context">The injected database context</param>
        /// <param name="fileFactory">The injected file factory</param>
        /// <param name="configuration">The injected configuration</param>
        public CategoryContext(DbContext context, IFileFactory fileFactory, IApplicationConfiguration configuration)
        {
            _fileFactory = fileFactory;
            _configuration = configuration;
            _context = context;
        }

        #endregion

        #region Get All

        /// <summary>
        /// Gets an <see cref="IQueryable"/> of <see cref="Category{T}"/> from the database
        /// </summary>
        /// <returns>An <see cref="IQueryable{T}"/> of <see cref="Category{T}"/></returns>
        public IQueryable<Category<T>> GetAll()
        {
            return _context.Set<Category<T>>().Include(c => c.Images).Include(c => c.SubCategories).ThenInclude(c => c.SubCategories);
        }

        /// <summary>
        /// Gets an <see cref="IQueryable{T}"/> parent <see cref="Category{T}"/> from the database
        /// </summary>
        /// <param name="departmentId">The identity of the parent <see cref="Department{T}"/> of the children that must be retrieved</param>
        /// <returns>An <see cref="IQueryable{T}"/> of parent <see cref="Category{T}"/></returns>
        public IQueryable<Category<T>> GetAllDepartmentCategories(string departmentId)
        {
            return (GetAll()).Where(c => c.DepartmentId == departmentId);
        }

        /// <summary>
        /// Gets an <see cref="IQueryable{T}"/> parent <see cref="Category{T}"/> from the database
        /// </summary>
        /// <param name="parentId">The identity of the parent <see cref="Category{T}"/> of the children that must be retrieved</param>
        /// <param name="departmentId">The identity of the parent <see cref="Department{T}"/> of the children that must be retrieved</param>
        /// <returns>An <see cref="IQueryable{T}"/> of parent <see cref="Category{T}"/></returns>
        public IQueryable<Category<T>> GetAllCategories(string parentId = null)
        {
            return (GetAll()).Where(c => c.ParentCategoryId == parentId);
        }

        /// <summary>
        /// Gets an <see cref="IQueryable{T}"/> child <see cref="Category{T}"/> from the database the belongs to a specific parent
        /// </summary>
        /// <param name="id">The identity of the parent <see cref="Department{T}"/> of the children that must be retrieved</param>
        /// <returns>An <see cref="IQueryable{T}"/> of child <see cref="Category{T}"/></returns>
        public IEnumerable<T> GetAllCategoryEntities(string id)
        {
            var result = _context.Set<EntityCategory<T>>().Include(c => c.Entity).Where(c => c.CategoryId == id);
            var list = new List<T>();
            foreach (var item in result)
            {
                list.Add(item.Entity);
            }

            return list;
        }
        
        /// <summary>
        /// Get a specific <see cref="Category{T}"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="Category{T}"/> that must be retrieved</param>
        /// <returns>The <see cref="Category{T}"/> specified by the identity</returns>
        public async Task<Category<T>> GetAsync(string id)
        {
            return await (GetAll()).FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Get the count of entities that belongs to the 
        /// </summary>
        /// <param name="categoryId">The categoryId that the </param>
        /// <returns></returns>
        public int GetEntityCount(string categoryId)
        {
            var result = _context.Set<EntityCategory<T>>().Where(c => c.CategoryId == categoryId);
            return result.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public int GetSubCategoryCount(string categoryId)
        {
            var result = GetAllCategories(categoryId);
            return result.Count();
        }

        /// <summary>
        /// Gets the previous database entry
        /// </summary>
        /// <param name="current">The current <see cref="Category{T}"/></param>
        /// <returns>The previous <see cref="Category{T}"/></returns>
        public async Task<Category<T>> GetPreviousAsync(Category<T> current)
        {
            var entityList = await _context.Set<Category<T>>().Include(c => c.Images).ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index > 0 ? entityList[index - 1] : null;
        }

        /// <summary>
        /// Gets the next database entry
        /// </summary>
        /// <param name="current">The current <see cref="Category{T}"/></param>
        /// <returns>The previous <see cref="Category{T}"/></returns>
        public async Task<Category<T>> GetNextAsync(Category<T> current)
        {
            var entityList = await _context.Set<Category<T>>().Include(c => c.Images).ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index < entityList.Count - 1 ? entityList[index + 1] : null;
        }

        #endregion

        #region Add Category

        /// <summary>
        /// Adds a <see cref="Category{T}"/> to the database asynchronously
        /// </summary>
        /// <param name="model">The <see cref="CategoryAddEditModel{T}"/> used to add the <see cref="Category{T}"/></param>
        /// <returns>The <see cref="Category{T}"/> that was added</returns>
        public async Task<Category<T>> AddAsync(CategoryAddEditModel<T> model)
        {
            await _context.Set<Category<T>>().AddAsync(model.Entity);

            var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Category<T>>(model.CoverUpload, null, "images/uploads/categories/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
            var banner = await _fileFactory.UploadImageAndSaveToDbAsync<Category<T>>(model.IconUpload, null, "images/uploads/categories/icons", ImageType.Icon, new Point(Convert.ToInt16(model.IconCropSettings.X), Convert.ToInt16(model.IconCropSettings.Y)), new Size(Convert.ToInt16(model.IconCropSettings.Width), Convert.ToInt16(model.IconCropSettings.Height)), model.Entity.Id);
            var slider = await _fileFactory.UploadImageAndSaveToDbAsync<Category<T>>(model.BannerUpload, null, "images/uploads/categories/banners", ImageType.Banner, new Point(Convert.ToInt16(model.BannerCropSettings.X), Convert.ToInt16(model.BannerCropSettings.Y)), new Size(Convert.ToInt16(model.BannerCropSettings.Width), Convert.ToInt16(model.BannerCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUploads != null && model.ImagesUploads.Any())
            {
                foreach (var item in model.ImagesUploads)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<T>(item, null, "images/uploads/categories/images", ImageType.Image, new Point(0, 0), new Size(900, 500), model.Entity.Id, true);
                }
            }

            await _context.SaveChangesAsync();
            return model.Entity;
        }

        #endregion

        #region Update Category

        /// <summary>
        /// Update a specific <see cref="Department{T}"/> ont the database
        /// </summary>
        /// <param name="model">The <see cref="DepartmentAddEditModel{T}"/> to be updated from</param>
        /// <returns>The updated <see cref="Department{T}"/></returns>
        public async Task<Category<T>> UpdateAsync(CategoryAddEditModel<T> model)
        {
            var category = _context.Set<Category<T>>().Include(c => c.Images).FirstOrDefault(c => c.Id == model.Entity.Id);

            _context.Entry(category).CurrentValues.SetValues(model.Entity);

            _context.Set<Category<T>>().Update(category);

            var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Category<T>>(model.CoverUpload, category.GetImage()?.Id, "images/uploads/categories/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
            var banner = await _fileFactory.UploadImageAndSaveToDbAsync<Category<T>>(model.IconUpload, category.GetImage(ImageType.Icon)?.Id, "images/uploads/categories/icons", ImageType.Icon, new Point(Convert.ToInt16(model.IconCropSettings.X), Convert.ToInt16(model.IconCropSettings.Y)), new Size(Convert.ToInt16(model.IconCropSettings.Width), Convert.ToInt16(model.IconCropSettings.Height)), model.Entity.Id);
            var slider = await _fileFactory.UploadImageAndSaveToDbAsync<Category<T>>(model.BannerUpload, category.GetImage(ImageType.Banner)?.Id, "images/uploads/categories/banners", ImageType.Banner, new Point(Convert.ToInt16(model.BannerCropSettings.X), Convert.ToInt16(model.BannerCropSettings.Y)), new Size(Convert.ToInt16(model.BannerCropSettings.Width), Convert.ToInt16(model.BannerCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUploads != null && model.ImagesUploads.Any())
            {
                foreach (var item in model.ImagesUploads)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<T>(item, null, "images/uploads/categories/images", ImageType.Image, new Point(0, 0), new Size(900, 500), model.Entity.Id, true);
                }
            }


            await _context.SaveChangesAsync();

            return model.Entity;
        }

        public IQueryable<EntityCategory<T>> GetEntityCategories(string categoryId)
        {
            return _context.Set<EntityCategory<T>>().Include(c => c.Entity).Where(c => c.CategoryId == categoryId);
        }

        public async Task<EntityCategory<T>> GetEntityCategory(string problemId, string categoryId)
        {
            return await _context.Set<EntityCategory<T>>().Where(c => c.EntityId == problemId).FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public async Task ProcessEntityCategories(string parentId, ICollection<CheckBoxSelectionModel<Category<T>>> categories)
        {
            if (categories.Any())
            {
                var currentCategories = _context.Set<EntityCategory<T>>().Where(c => c.EntityId == parentId);
                foreach (var item in currentCategories.ToList())
                {
                    await RemoveEntityCategory(item);
                }

                foreach (var item in categories)
                {
                    await ProcessAvailableCategories(parentId, item);
                }
            }
        }

        private async Task ProcessAvailableCategories(string parentId, CheckBoxSelectionModel<Category<T>> item)
        {
            if (item.HasChildSelection)
            {
                foreach (var ss in item.ChildSelection)
                {
                    await ProcessAvailableCategories(parentId, ss);
                }
            }

            if (item.IsSelected)
            {
                await ProcessSelectedCategoryParentAsync(item.Identity, parentId);
                await AddEntityCategory(new EntityCategory<T>(parentId, item.Identity));
            }
        }

        private async Task ProcessSelectedCategoryParentAsync(string categoryId, string parentId)
        {
            var category = await _context.Set<Category<T>>().FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category.ParentCategoryId != null)
            {
                await AddEntityCategory(new EntityCategory<T>(parentId, category.ParentCategoryId));
                await ProcessSelectedCategoryParentAsync(category.ParentCategoryId, parentId);
            }
        }

        public async Task<EntityCategory<T>> AddEntityCategory(EntityCategory<T> category)
        {
            _context.Set<EntityCategory<T>>().Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<EntityCategory<T>> RemoveEntityCategory(EntityCategory<T> category)
        {
            _context.Set<EntityCategory<T>>().Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        #endregion

        #region Delete Category

        /// <summary>
        /// Deletes a specific <see cref="Category{T}"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="Category{T}"/> to be deleted from the database</param>
        /// <returns>The deleted blog post</returns>
        public async Task DeleteAsync(string id)
        {
            await RemoveCategory(id);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Checks for sub-categories and removes them with their children
        /// otherwise removes the <see cref="Category{T}"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="Category{T}"/> that must be removed</param>
        public async Task RemoveCategory(string id)
        {
            // Get the file to be deleted
            Category<T> file = _context.Set<Category<T>>().Include(c => c.Images).Include(c => c.SubCategories).ThenInclude(c => c.SubCategories)
                .Include(c => c.EntityCollection).FirstOrDefault(c => c.Id == id);

            if (file.SubCategories != null && file.SubCategories.Any())
            {
                foreach (var sub in file.SubCategories)
                {
                    await RemoveCategory(sub.Id);
                }
            }

            if (file.Images != null && file.Images.Any())
            {
                foreach (var photoAlbum in file.Images.ToList())
                {
                    await _fileFactory.DeleteImageAndRemoveFormDbAsync(photoAlbum);
                    file.Images.Remove(photoAlbum);
                }
            }

            if (file.EntityCollection != null && file.EntityCollection.Any())
            {
                foreach (var photoAlbum in file.EntityCollection.ToList())
                {
                    _context.Set<EntityCategory<T>>().Remove(photoAlbum);
                    await _context.SaveChangesAsync();
                }
            }

            _context.Set<Category<T>>().Remove(file);
        }

        #endregion

        /// <summary>
        /// Gets all the departments
        /// </summary>
        public IQueryable<Department<T>> GetAllDepartments()
        {
            return _context.Set<Department<T>>().Include(c => c.Images);
        }

        /// <summary>
        /// Removes a single image
        /// </summary>
        /// <param name="id">The identity of the image that must be removed</param>
        public async Task RemoveImage(string id)
        {
            // Get the file to be deleted
            var file = _context.Set<ImageFile<T>>().FirstOrDefault(c => c.Id == id);
            await _fileFactory.DeleteImageAndRemoveFormDbAsync<T>(file);
            _context.SaveChanges();
        }
    }
}
