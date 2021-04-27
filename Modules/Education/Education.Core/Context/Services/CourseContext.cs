using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Education.Base.Entities;
using Education.Core.Models;
using Filing.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Grouping.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace Education.Core.Context.Services
{
    /// <summary>
    /// The database context service
    /// </summary>
    public class CourseContext
    {
        private readonly DbContext _context;
        private readonly IFileFactory _fileFactory;

        #region Constructors

        /// <summary>
        /// The default Constructor
        /// </summary>
        /// <param name="context">The injected database context</param>
        public CourseContext(DbContext context, IFileFactory fileFactory)
        {
            _context = context;
            _fileFactory = fileFactory;
        }

        #endregion

        #region Get All

        /// <summary>
        /// Gets a <see cref="IQueryable{T}"/> of courses from the database
        /// </summary>
        /// <returns>A list of training courses</returns>
        public IQueryable<Course> GetAll()
        {
            return _context.Set<Course>().Include(c => c.Images)
                .Include(c => c.Modules).Include(c => c.AssessmentElements).Include(c => c.Students).ThenInclude(c => c.Student);
        }

        /// <summary>
        /// Gets a <see cref="IQueryable{T}"/> of courses from the database
        /// </summary>
        /// <returns>A list of training courses</returns>
        public async Task<Course> GetAsync(string id)
        {
            return await GetAll().FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Gets the previous database entry
        /// </summary>
        /// <param name="current">The current <see cref="Department{T}"/></param>
        /// <returns>The previous <see cref="Department{T}"/></returns>
        public async Task<Course> GetPreviousAsync(Course current)
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
        public async Task<Course> GetNextAsync(Course current)
        {
            var entityList = await GetAll().Include(c => c.Images).ToListAsync();

            // Get the index of the blog entry
            var index = entityList.IndexOf(current);
            return index < entityList.Count - 1 ? entityList[index + 1] : null;
        }

        #endregion

        #region Add Training Course

        /// <summary>
        /// Adds a <see cref="Course"/> to the database asynchronously
        /// </summary>
        /// <param name="model">The <see cref="CourseAddEditModel"/> used to add the <see cref="Course"/></param>
        /// <returns>The <see cref="Course"/> that was added</returns>
        public async Task<Course> AddAsync(CourseAddEditModel model)
        {
            await _context.Set<Course>().AddAsync(model.Entity);

            await _fileFactory.UploadImageAndSaveToDbAsync<Course>(model.CoverUpload, null, "images/uploads/course/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
            await _fileFactory.UploadImageAndSaveToDbAsync<Course>(model.IconUpload, null, "images/uploads/course/icons", ImageType.Icon, new Point(Convert.ToInt16(model.IconCropSettings.X), Convert.ToInt16(model.IconCropSettings.Y)), new Size(Convert.ToInt16(model.IconCropSettings.Width), Convert.ToInt16(model.IconCropSettings.Height)), model.Entity.Id);
            await _fileFactory.UploadImageAndSaveToDbAsync<Course>(model.BannerUpload, null, "images/uploads/course/banners", ImageType.Banner, new Point(Convert.ToInt16(model.BannerCropSettings.X), Convert.ToInt16(model.BannerCropSettings.Y)), new Size(Convert.ToInt16(model.BannerCropSettings.Width), Convert.ToInt16(model.BannerCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUploads != null && model.ImagesUploads.Any())
            {
                foreach (var item in model.ImagesUploads)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<Course>(item, null, "images/uploads/course/images", ImageType.Image, new Point(0, 0), new Size(900, 500), model.Entity.Id, true);
                }
            }

            await _context.SaveChangesAsync();
            return model.Entity;
        }

        #endregion

        #region Update Department

        /// <summary>
        /// Update a specific <see cref="Course"/> ont the database
        /// </summary>
        /// <param name="model">The <see cref="CourseAddEditModel"/> to be updated from</param>
        /// <returns>The updated <see cref="Course"/></returns>
        public async Task<Course> UpdateAsync(CourseAddEditModel model)
        {
            var category = await GetAsync(model.Entity.Id);

            _context.Entry(category).CurrentValues.SetValues(model.Entity);


            if (!string.IsNullOrEmpty(model.Entity.FileFolder))
            {
                var path = Path.Combine("Courses", model.Entity.Name);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }

            _context.Set<Course>().Update(category);

            await _fileFactory.UploadImageAndSaveToDbAsync<Course>(model.CoverUpload, category.GetImage()?.Id, "images/uploads/course/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Entity.Id);
            await _fileFactory.UploadImageAndSaveToDbAsync<Course>(model.IconUpload, category.GetImage(ImageType.Icon)?.Id, "images/uploads/course/icons", ImageType.Icon, new Point(Convert.ToInt16(model.IconCropSettings.X), Convert.ToInt16(model.IconCropSettings.Y)), new Size(Convert.ToInt16(model.IconCropSettings.Width), Convert.ToInt16(model.IconCropSettings.Height)), model.Entity.Id);
            await _fileFactory.UploadImageAndSaveToDbAsync<Course>(model.BannerUpload, category.GetImage(ImageType.Banner)?.Id, "images/uploads/course/banners", ImageType.Banner, new Point(Convert.ToInt16(model.BannerCropSettings.X), Convert.ToInt16(model.BannerCropSettings.Y)), new Size(Convert.ToInt16(model.BannerCropSettings.Width), Convert.ToInt16(model.BannerCropSettings.Height)), model.Entity.Id);

            if (model.ImagesUploads != null && model.ImagesUploads.Any())
            {
                foreach (var item in model.ImagesUploads)
                {
                    var image = await _fileFactory.UploadImageAndSaveToDbAsync<Course>(item, null, "images/uploads/course/images", ImageType.Image, new Point(0, 0), new Size(900, 500), model.Entity.Id, true);
                }
            }

            await _context.SaveChangesAsync();

            return model.Entity;
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            if (!string.IsNullOrEmpty(course.FullPath))
            {
                var path = Path.Combine("Courses", course.Name);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }

            _context.Set<Course>().Update(course);
            await _context.SaveChangesAsync();

            return course;
        }

        #endregion

        #region Delete Department

        /// <summary>
        /// Deletes a specific <see cref="Course"/>
        /// </summary>
        /// <param name="id">The identity of the <see cref="Course"/> to be deleted from the database</param>
        public async Task DeleteAsync(string id)
        {
            Course department = await GetAsync(id);
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

        public async Task<AssessmentElement<T>> AddAssessmentElementAsync<T>(AssessmentElement<T> formElement)
        {
            _context.Set<AssessmentElement<T>>().Add(formElement);
            await _context.SaveChangesAsync();

            return formElement;
        }

        /// <summary>
        /// Removes a single image
        /// </summary>
        /// <param name="id">The identity of the image that must be removed</param>
        public async Task RemoveImage(string id)
        {
            // Get the file to be deleted
            var file = _context.Set<ImageFile<Course>>().FirstOrDefault(c => c.Id == id);
            await _fileFactory.DeleteImageAndRemoveFormDbAsync<Course>(file);
            _context.SaveChanges();
        }

        public async Task RemoveCourseAssessmentElementAsync(string id)
        {
            var formElement = _context.Set<AssessmentElement<Course>>().FirstOrDefault(c => c.Id == id);

            _context.Set<AssessmentElement<Course>>().Remove(formElement);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveModuleAssessmentElementAsync(string id)
        {
            var formElement = _context.Set<AssessmentElement<Module>>().FirstOrDefault(c => c.Id == id);

            _context.Set<AssessmentElement<Module>>().Remove(formElement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentCourseAsync(string studentId, string courseId)
        {
            var studentCourse = _context.Set<StudentCourse>().Where(c => c.StudentId == studentId).FirstOrDefault(c => c.CourseId == courseId);

            _context.Set<StudentCourse>().Add(studentCourse);
            await _context.SaveChangesAsync();
        }
    }
}
