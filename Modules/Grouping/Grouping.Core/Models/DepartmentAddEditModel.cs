using System.Collections.Generic;
using Filing.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;

namespace Grouping.Core.Models
{
    /// <summary>
    /// The base <see cref="Department{T}"/> add/edit model
    /// </summary>
    /// <typeparam name="T">The type of <see cref="Department{T}"/> featured by this model</typeparam>
    public class DepartmentAddEditModel<T> : AddEditModelBase<Department<T>> where T : IEntityBase, new()
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Parameter less Constructor
        /// </summary>
        public DepartmentAddEditModel() { }

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="department">The <see cref="Department{T}"/> featured by this model</param>
        public DepartmentAddEditModel(Department<T> department) : base(department) { }

        #endregion

        /// <summary>
        /// The Icon of the <see cref="Department{T}"/>
        /// </summary>
        public IFormFile IconUpload { get; set; }
        public CropSettings IconCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The coverImage of the <see cref="Department{T}"/>
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The banner image of the <see cref="Department{T}"/>
        /// </summary>
        public IFormFile BannerUpload { get; set; }
        public CropSettings BannerCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The Image collection of the <see cref="Department{T}"/>
        /// </summary>
        public ICollection<IFormFile> ImagesUploads { get; set; }
    }
}
