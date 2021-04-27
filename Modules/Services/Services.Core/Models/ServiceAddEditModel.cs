using System.Collections.Generic;
using System.Linq;
using Filing.Base.Entities;
using Filing.Base.Extensions;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;
using Services.Base.Entities;

namespace Services.Core.Models
{
    /// <summary>
    /// The model used when adding a new Service
    /// </summary>
    public class ServiceAddEditModel : AddEditModelBase<Service>
    {
        #region Constructors   

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ServiceAddEditModel() : base(new Service()) { }

        /// <summary>
        /// Default Constructor with service parameter
        /// </summary>
        /// <param name="service">The service used to construct the model</param>
        /// <param name="categories">A list of categories this service is included in</param>
        public ServiceAddEditModel(Service service, IEnumerable<Category<Service>> categories) : base(service)
        {
            if (service.Categories != null)
            {
                foreach (var item in service.Categories)
                {
                    SelectedCategoryIds.Add(item.CategoryId);
                }
            }

            AddToAvailableCategories(categories.ToList());
        }

        /// <summary>
        /// Adds a category to the available categories list
        /// </summary>
        /// <param name="list">A list of already available categories</param>
        private void AddToAvailableCategories(ICollection<Category<Service>> list)
        {
            foreach (var item in list)
            {
                var checkboxModel = new CheckBoxSelectionModel<Category<Service>>(item.Id, item.ParentCategoryId, item.Name, item.GetPath(), item.Description);

                if (Entity.Categories.Any(c => c.CategoryId == item.Id))
                    checkboxModel.IsSelected = true;

                AvailableCategories.Add(checkboxModel);

                AddToAvailableCategories(item.SubCategories);
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the collection of selected categories
        /// </summary>
        public ICollection<string> SelectedCategoryIds { get; set; } = new List<string>();

        /// <summary>
        /// Gets of sets the collection of checkboxes for the categories available for a service
        /// </summary>
        public List<CheckBoxSelectionModel<Category<Service>>> AvailableCategories { get; set; } = new List<CheckBoxSelectionModel<Category<Service>>>();

        /// <summary>
        /// Gets or sets the image file that is used for a cover upload
        /// </summary>
        public IFormFile CoverUpload { get; set; }

        /// <summary>
        /// Gets or sets the crop setting used for the cover image
        /// </summary>
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// Gets or sets the image file that is used for a icon upload
        /// </summary>
        public IFormFile IconUpload { get; set; }
        /// <summary>
        /// Gets or sets the crop setting used for the icon image
        /// </summary>
        public CropSettings IconCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// Gets or sets the image file that is used for a banner upload
        /// </summary>
        public IFormFile BannerUpload { get; set; }
        public CropSettings BannerCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// Gets or sets the audio file that is used for upload
        /// </summary>
        public IFormFile AudioUpload { get; set; }

        /// <summary>
        /// Gets or sets the video file that is used for upload
        /// </summary>
        public IFormFile VideoUpload { get; set; }

        /// <summary>
        /// Gets or Sets the collection of files tha is used as extra image uploads
        /// </summary>
        public ICollection<IFormFile> ImagesUpload { get; set; } = new List<IFormFile>();
    }
}
