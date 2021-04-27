using System.Collections.Generic;
using System.ComponentModel;
using Filing.Base.Entities;
using Grouping.Base.Entities;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;

namespace Grouping.Core.Models
{
    /// <summary>
    /// The base <see cref="Category{T}"/> add/edit model
    /// </summary>
    /// <typeparam name="T">The type of <see cref="Category{T}"/> featured by this model</typeparam>
    public class CategoryAddEditModel<T> : AddEditModelBase<Category<T>> where T : IEntityBase, new()
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Parameter less Constructor
        /// </summary>
        public CategoryAddEditModel() { }

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="category">The <see cref="Category{T}"/> featured by this model</param>
        public CategoryAddEditModel(Category<T> category) : base(category) { }

        #endregion

        /// <summary>
        /// The identity of the parent category if any
        /// </summary>
        public string ParentCategoryId { get; set; }

        /// <summary>
        /// The identity of the parent department if any
        /// </summary>
        public string ParentDepartmentId { get; set; }

        /// <summary>
        /// A list of <see cref="Department{T}"/>
        /// </summary>
        public IEnumerable<Department<T>> Departments { get; set; }

        /// <summary>
        /// The currently selected <see cref="Department{T}"/>
        /// </summary>
        
        [DisplayName("Department")]
        public Department<T> SelectedDepartment { get; set; }

        /// <summary>
        /// The Icon of the <see cref="Category{T}"/>
        /// </summary>
        public IFormFile IconUpload { get; set; }
        public CropSettings IconCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The coverImage of the <see cref="Category{T}"/>
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The Banner of the <see cref="Category{T}"/>
        /// </summary>
        public IFormFile BannerUpload { get; set; }
        public CropSettings BannerCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The Image collection of the <see cref="Category{T}"/>
        /// </summary>
        public ICollection<IFormFile> ImagesUploads { get; set; }
    }
}
