using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Grouping.Entities;
using Iqt.Base.Interfaces;
using Iqt.Filing.Entities;
using Iqt.Filing.Enums;
using Microsoft.EntityFrameworkCore;

namespace Grouping.Context.Services
{
    public class DepartmentContext<T> where T : IEntityBase, new()
    {

        private readonly DbContext _context;

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// The default constructor  with injected parameters
        /// </summary>
        /// <param name="context">The injected database context</param>
        /// <param name="fileFactory">The injected file factory</param>
        public DepartmentContext(DbContext context)
        {
            _context = (DbContext)context;
        }

        #endregion

        #region Get All

        /// <summary>
        /// Gets an <see cref="IQueryable"/> of <see cref="Department{T}"/> from the database
        /// </summary>
        /// <returns>An <see cref="IQueryable{T}"/> of <see cref="Department{T}"/></returns>
        public IQueryable<Department<T>> GetAll()
        {
            return _context.Set<Department<T>>().Include(c => c.Images).Include(c => c.Categories);
        }

        /// <summary>
        /// Gets a <see cref="IQueryable{T}"/> department <see cref="Department{T}"/> from the database
        /// including the full child category tree
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable{T}"/> of <see cref="Department{T}"/>
        /// including the full child category tree
        /// </returns>
        public IQueryable<Department<T>> GetAllWithCategoriesTree()
        {
            return _context.Set<Department<T>>()
                .Include(c => c.Categories).ThenInclude(c => c.Images)
                .Include(c => c.Categories).ThenInclude(c => c.SubCategories).ThenInclude(c => c.Images);
        }

        /// <summary>
        /// Get a specific <see cref="Department{T}"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="Department{T}"/> that must be retrieved</param>
        /// <returns>The <see cref="Department{T}"/> specified by the identity</returns>
        public Task<Department<T>> GetAsync(string id)
        {
            return GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Gets the previous database entry
        /// </summary>
        /// <param name="current">The current <see cref="Department{T}"/></param>
        /// <returns>The previous <see cref="Department{T}"/></returns>
        public async Task<Department<T>> GetPreviousAsync(Department<T> current)
        {
            var entityList = await GetAll().ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index > 0 ? entityList[index - 1] : null;
        }

        /// <summary>
        /// Gets the next database entry
        /// </summary>
        /// <param name="current">The current <see cref="Department{T}"/></param>
        /// <returns>The previous <see cref="Department{T}"/></returns>
        public async Task<Department<T>> GetNextAsync(Department<T> current)
        {
            var entityList = await GetAll().Include(c => c.Images).ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index < entityList.Count - 1 ? entityList[index + 1] : null;
        }

        #endregion

        #region Add Department

        /// <summary>
        /// Adds a <see cref="Department{T}"/> to the database asynchronously
        /// </summary>
        /// <param name="model">The <see cref="DepartmentAddEditModel{T}"/> used to add the <see cref="Department{T}"/></param>
        /// <returns>The <see cref="Department{T}"/> that was added</returns>
        public async Task<Department<T>> AddAsync(Department<T> department, ImageFile<Department<T>> CoverImage)
        {
            await _context.Set<Department<T>>().AddAsync(model.Entity);

            await _fileFactory.UploadImageAndSaveToDbAsync<Department<T>>(model.CoverUpload, null, "images/uploads/departments/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
            await _fileFactory.UploadImageAndSaveToDbAsync<Department<T>>(model.IconUpload, null, "images/uploads/departments/icons", ImageType.Icon, new Point(Convert.ToInt16(model.IconCropSettings.X), Convert.ToInt16(model.IconCropSettings.Y)), new Size(Convert.ToInt16(model.IconCropSettings.Width), Convert.ToInt16(model.IconCropSettings.Height)), model.Entity.Id);
            await _fileFactory.UploadImageAndSaveToDbAsync<Department<T>>(model.BannerUpload, null, "images/uploads/departments/banners", ImageType.Banner, new Point(Convert.ToInt16(model.BannerCropSettings.X), Convert.ToInt16(model.BannerCropSettings.Y)), new Size(Convert.ToInt16(model.BannerCropSettings.Width), Convert.ToInt16(model.BannerCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUploads != null && model.ImagesUploads.Any())
            {
                foreach (var item in model.ImagesUploads)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<T>(item, null, "images/uploads/departments/images", ImageType.Image, new Point(0, 0), new Size(900, 500), model.Entity.Id, true);
                }
            }

            await _context.SaveChangesAsync();
            return model.Entity;
        }

        #endregion

        #region Update Department

        /// <summary>
        /// Update a specific <see cref="Department{T}"/> ont the database
        /// </summary>
        /// <param name="model">The <see cref="DepartmentAddEditModel{T}"/> to be updated from</param>
        /// <returns>The updated <see cref="Department{T}"/></returns>
        public async Task<Department<T>> UpdateAsync(DepartmentAddEditModel<T> model)
        {
            var category = await GetAsync(model.Entity.Id);

            _context.Entry(category).CurrentValues.SetValues(model.Entity);

            _context.Set<Department<T>>().Update(category);

            await _fileFactory.UploadImageAndSaveToDbAsync<Department<T>>(model.CoverUpload, category.GetImage()?.Id, "images/uploads/departments/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
            await _fileFactory.UploadImageAndSaveToDbAsync<Department<T>>(model.IconUpload, category.GetImage(ImageType.Icon)?.Id, "images/uploads/departments/icons", ImageType.Icon, new Point(Convert.ToInt16(model.IconCropSettings.X), Convert.ToInt16(model.IconCropSettings.Y)), new Size(Convert.ToInt16(model.IconCropSettings.Width), Convert.ToInt16(model.IconCropSettings.Height)), model.Entity.Id);
            await _fileFactory.UploadImageAndSaveToDbAsync<Department<T>>(model.BannerUpload, category.GetImage(ImageType.Banner)?.Id, "images/uploads/departments/banners", ImageType.Banner, new Point(Convert.ToInt16(model.BannerCropSettings.X), Convert.ToInt16(model.BannerCropSettings.Y)), new Size(Convert.ToInt16(model.BannerCropSettings.Width), Convert.ToInt16(model.BannerCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUploads != null && model.ImagesUploads.Any())
            {
                foreach (var item in model.ImagesUploads)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<T>(item, null, "images/uploads/departments/images", ImageType.Image, new Point(0, 0), new Size(900, 500), model.Entity.Id, true);
                }
            }

            await _context.SaveChangesAsync();

            return model.Entity;
        }

        #endregion

        #region Delete Department

        /// <summary>
        /// Deletes a specific <see cref="Department{T}"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="Department{T}"/> to be deleted from the database</param>
        public async Task DeleteAsync(string id)
        {
            Department<T> department = await GetAsync(id);
            if (department.Images != null && department.Images.Any())
            {
                foreach (var photoAlbum in department.Images.ToList())
                {
                    await _fileFactory.DeleteImageAndRemoveFormDbAsync(photoAlbum);
                    department.Images.Remove(photoAlbum);
                }
            }
            _context.Remove(department);

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

        #endregion

        /// <summary>
        /// Removes a single image
        /// </summary>
        /// <param name="id">The identity of the image that must be removed</param>
        public async Task RemoveImage(string id)
        {
            // Get the file to be deleted
            var file = _context.Set<ImageFile<Department<T>>>().FirstOrDefault(c => c.Id == id);
            await _fileFactory.DeleteImageAndRemoveFormDbAsync<Department<T>>(file);
            _context.SaveChanges();
        }
    }
}
