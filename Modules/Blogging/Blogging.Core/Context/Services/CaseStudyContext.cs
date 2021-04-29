using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Blogging.Base.Entities;
using Blogging.Core.Models;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Core.Context.Services
{
    /// <summary>
    /// The context service that manages case study details in the database
    /// </summary>
    public class CaseStudyContext
    {
        private readonly DbContext _context;
        private readonly IFileFactory _fileFactory;

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// The default constructor  with injected parameters
        /// </summary>
        /// <param name="context">The injected database context</param>
        /// <param name="fileFactory">The injected file factory</param>
        public CaseStudyContext(IFileFactory fileFactory, DbContext context)
        {
            _fileFactory = fileFactory;
            _context = context;
        }

        #endregion

        #region Get all case studies

        /// <summary>
        /// Get an <see cref="IQueryable" /> list of all the case studies
        /// </summary>
        /// <returns>An <see cref="IQueryable" /> list of all the case studies</returns>
        public IQueryable<CaseStudy> GetAll()
        {
            return _context.Set<CaseStudy>()
                .Include(post => post.AudioFile)
                .Include(c => c.Images)
                .Include(b => b.Categories);
        }

        /// <summary>
        /// Get an <see cref="IQueryable" /> list of all the case studies
        /// </summary>
        /// <returns>An <see cref="IQueryable" /> list of all the case studies</returns>
        public async Task<CaseStudy> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Get a enumerated list of the case studies 
        /// filtered by month
        /// </summary>
        /// <param name="month">The month that should be filtered by</param>
        /// <param name="year">The year that should be filtered</param>
        /// <returns>An enumerated list of all the blog entries</returns>
        public IEnumerable<CaseStudy> GetAllByMonth(int month, int? year = null)
        {
            if (year == null)
                year = DateTime.Now.Year;

            return GetAll().Where(c => c.Created.Month == month).Where(c => c.Created.Year == year).ToList();
        }

        /// <summary>
        /// Get an <see cref="IQueryable" /> list of all the case studies
        /// </summary>
        /// <returns>An <see cref="IQueryable" /> list of all the case studies</returns>
        public IQueryable<CaseStudy> GetAllFeatured()
        {
            return _context.Set<CaseStudy>().Where(c => c.Featured).OrderByDescending(c => c.Created);
        }

        /// <summary>
        /// Gets the previous entry
        /// </summary>
        /// <param name="current">The current entity</param>
        /// <returns>the previous entry if this is not the first entry otherwise it returns the first entry</returns>
        public async Task<CaseStudy> GetPreviousAsync(CaseStudy current)
        {
            var entityList = await GetAll().Where(c => c.Active).ToListAsync();

            // Get the index of the case study
            var index = entityList.IndexOf(current);
            return index > 0 ? entityList[index - 1] : null;
        }

        /// <summary>
        /// Gets the last case study
        /// </summary>
        /// <param name="current">The current case study</param>
        /// <returns>the next entry if this is not the last entry otherwise it returns the last entry</returns>
        public async Task<CaseStudy> GetNextAsync(CaseStudy current)
        {
            var entityList = await GetAll().Where(c => c.Active).ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index < entityList.Count - 1 ? entityList[index + 1] : null;
        }

        #endregion

        #region Add Blog Entry

        /// <summary>
        /// Adds a case study to the database asyncronously
        /// </summary>
        /// <param name="model">The model used for the update</param>
        /// <param name="imageSettings">The image settings used to upload images</param>
        /// <returns>The case study that was added</returns>
        public async Task<CaseStudy> AddAsync(CaseStudyAddEditModel model)
        {
            _context.Set<CaseStudy>().Add(model.Entity);

            foreach (var item in model.AvailableCategories)
            {
                await ProcessAvailableCategories(model.Entity, item);
            }

            await _fileFactory.UploadImageAndSaveToDbAsync<CaseStudy>(model.CoverUpload, null, "images/uploads/casestudies/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUpload != null && model.ImagesUpload.Any())
            {
                foreach (var item in model.ImagesUpload)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<BlogPost>(item, null, "images/uploads/casestudies/images", ImageType.Image, new Point(0, 0), new Size(900, 500), model.Entity.Id, true);
                }
            }

            if (model.AudioUpload != null)
                await _fileFactory.UploadAudioAndSaveToDbAsync<BlogPost>(model.AudioUpload, model.Entity.AudioFileId, @model.Entity.Title + " " + "Audio File", @model.Entity.Title + " " + "Audio File", "audio/uploads/casestudies");
            if (model.VideoUpload != null)
                await _fileFactory.UploadVideoAndSaveToDbAsync<BlogPost>(model.VideoUpload, model.Entity.AudioFileId, @model.Entity.Title + " " + "Video", @model.Entity.Title + " " + "Video File", "videos/uploads/casestudies");

            await _context.SaveChangesAsync();

            return model.Entity;
        }

        #endregion

        #region Update Blog Post

        /// <summary>
        /// Update a specific employee
        /// </summary>
        /// <param name="model">The model to be updated from</param>
        /// <param name="imageSettings">The image settings used to upload the files</param>
        /// <returns>The updated blog post</returns>
        public async Task<CaseStudy> UpdateAsync(CaseStudyAddEditModel model)
        {
            foreach (var item in model.AvailableCategories)
            {
                await ProcessAvailableCategories(model.Entity, item);
            }

            var cover = await _fileFactory.UploadImageAndSaveToDbAsync<CaseStudy>(model.CoverUpload, model.Entity.GetImage()?.Id, "images/uploads/casestudies/covers", ImageType.Cover,
                new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)),
                new Size(Convert.ToInt16(model.CoverCropSettings.Width),
                    Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUpload != null && model.ImagesUpload.Any())
            {
                foreach (var item in model.ImagesUpload)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<CaseStudy>(item, null,
                        "images/uploads/casestudies/images", ImageType.Image, new Point(0, 0), new Size(900, 500),
                        model.Entity.Id, true);
                }
            }

            if (model.AudioUpload != null)
                await _fileFactory.UploadAudioAndSaveToDbAsync<CaseStudy>(model.AudioUpload, model.Entity.AudioFileId,
                    @model.Entity.Title + " " + "Audio File", @model.Entity.Title + " " + "Audio File", "audio/uploads/casestudies");
            if (model.VideoUpload != null)
                await _fileFactory.UploadVideoAndSaveToDbAsync<CaseStudy>(model.VideoUpload, null,
                    @model.Entity.Title + " " + "Video", @model.Entity.Title + " " + "Video File", "videos/uploads/casestudies");

            try
            {
                _context.Set<CaseStudy>().Update(model.Entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return model.Entity;
        }

        #endregion

        #region Delete Blog Post

        /// <summary>
        /// Deletes a specific case study
        /// </summary>
        /// <param name="id">The identity of the case study to be deleted</param>
        /// <returns>The deleted case study</returns>
        public async Task<CaseStudy> DeleteAsync(string id)
        {
            // Gets the product to be deleted
            var blogPost = await GetAll().FirstOrDefaultAsync(c => c.Id == id);

            await DeletePost(blogPost);

            return blogPost;
        }

        private async Task DeletePost(CaseStudy post)
        {

            // Check to see if there is a dimension that should be deleted
            if (post.AudioFile != null)
            {
                _context.Set<AudioFile<CaseStudy>>().Remove(post.AudioFile);
            }

            // Check to see if there is a dimension that should be deleted
            if (post.Categories != null && post.Categories.Any())
            {
                foreach (var photoAlbum in post.Categories.ToList())
                {
                    _context.Set<EntityCategory<CaseStudy>>().Remove(photoAlbum);
                }
            }

            // Check to see if there is a dimension that should be deleted
            if (post.Images != null && post.Images.Any())
            {
                foreach (var photoAlbum in post.Images.ToList())
                {
                    await _fileFactory.DeleteImageAndRemoveFormDbAsync(photoAlbum);
                }
            }
            _context.Set<CaseStudy>().Remove(post);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region Children

        #region Categories

        /// <summary>
        /// Get an enumerated list of all the case study categories
        /// </summary>
        /// <returns>An enumerated list of all the case study categories</returns>
        public IEnumerable<Category<CaseStudy>> GetCategories()
        {
            return _context.Set<Category<CaseStudy>>().Include(c => c.Images).Include(c => c.SubCategories).Where(c => c.ParentCategoryId == null);
        }

        /// <summary>
        /// Get an enumerated list of all the case study sub-categories
        /// </summary>
        /// <returns>An enumerated list of all the case study sub-categories</returns>
        public IEnumerable<Category<CaseStudy>> GetSubCategories(string parentId)
        {
            return _context.Set<Category<CaseStudy>>().Include(c => c.Images).Where(c => c.ParentCategoryId == parentId);
        }

        private async Task ProcessAvailableCategories(CaseStudy parent, CheckBoxSelectionModel<Category<CaseStudy>> item)
        {
            if (item.HasChildSelection)
            {
                foreach (var ss in item.ChildSelection)
                {
                    await ProcessAvailableCategories(parent, ss);
                }
            }

            var result = await _context.Set<EntityCategory<CaseStudy>>().Where(c => c.CategoryId == item.Identity)
                .FirstOrDefaultAsync(c => c.EntityId == parent.Id);

            if (item.IsSelected && result == null)
            {
                _context.Set<EntityCategory<CaseStudy>>().Add(new EntityCategory<CaseStudy>(parent.Id, item.Identity));
            }
            else if (!item.IsSelected && result != null)
            {
                _context.Set<EntityCategory<CaseStudy>>().Remove(result);
            }
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
            var file = _context.Set<ImageFile<CaseStudy>>().FirstOrDefault(c => c.Id == id);
            try
            {
                _context.Set<ImageFile<CaseStudy>>().Remove(file);
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
