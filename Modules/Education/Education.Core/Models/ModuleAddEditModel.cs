using System.Collections.Generic;
using Education.Base.Entities;
using Filing.Base.Entities;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;

namespace Education.Core.Models
{
    /// <summary>
    /// The base <see cref="Module"/> add/edit model
    /// </summary>
    public class ModuleAddEditModel : AddEditModelBase<Module>
    {
        /// <summary>
        /// Flag to indicate if a documents folder should be created
        /// </summary>
        public bool DoNotCreateDocumentsFolder { get; set; }

        public Course ParentCourse { get; set; }

        #region Images

        /// <summary>
        /// The coverImage of the Product about to be uploaded
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();


        /// <summary>
        /// The icon image of the entity about to be uploaded
        /// </summary>
        public IFormFile IconUpload { get; set; }
        public CropSettings IconCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The banner image of the Product about to be uploaded
        /// </summary>
        public IFormFile BannerUpload { get; set; }
        public CropSettings BannerCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The images of the Product about to be uploaded
        /// </summary>
        public ICollection<IFormFile> ImagesUpload { get; set; } = new List<IFormFile>();

        #endregion

    }
}
