using System.Collections.Generic;
using Education.Base.Entities;
using Filing.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;

namespace Education.Core.Models
{
    /// <summary>
    /// The base <see cref="Course"/> add/edit model
    /// </summary>
    public class CourseAddEditModel : AddEditModelBase<Course>
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Parameter less Constructor
        /// </summary>
        public CourseAddEditModel() { }

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="department">The <see cref="Department{T}"/> featured by this model</param>
        public CourseAddEditModel(Course department) : base(department) { }

        #endregion
        

        /// <summary>
        /// The Icon of the <see cref="Course"/>
        /// </summary>
        public IFormFile IconUpload { get; set; }
        public CropSettings IconCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The coverImage of the <see cref="Course"/>
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The banner image of the <see cref="TrainingCourse"/>
        /// </summary>
        public IFormFile BannerUpload { get; set; }
        public CropSettings BannerCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The Image collection of the <see cref="TrainingCourse"/>
        /// </summary>
        public ICollection<IFormFile> ImagesUploads { get; set; }
    }
}
