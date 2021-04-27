using System.Collections.Generic;
using System.Linq;
using Calendar.Base.Entities;
using Filing.Base.Entities;
using Filing.Base.Extensions;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Calendar.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The model used when adding a new Product
    /// </summary>
    public class EventAddEditModel : AddEditModelBase<Event>
    {
        #region Constructors   

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        public EventAddEditModel() : base(new Event()) { }

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor with product parameter
        /// </summary>
        /// <param name="service">The blog post used to constuct the model</param>
        public EventAddEditModel(Event service):base(service) { }

        public EventAddEditModel(Event entity, IEnumerable<Category<Event>> categories) : base(entity)
        {
            if (entity.Categories != null)
            {
                foreach (var item in entity.Categories)
                {
                    SelectedCategoryIds.Add(item.CategoryId);
                }
            }

            AddToAvailableCategories(categories.Where(c => c.ParentCategoryId == null).ToList());
        }

        public void AddToAvailableCategories(ICollection<Category<Event>> list)
        {
            foreach (var category in list)
            {
                var checkboxModel = new CheckBoxSelectionModel<Category<Event>>(category.Id, category.ParentCategoryId, category.Name, category.GetPath(), category.Description);
                if (Entity.Categories.Any(c => c.CategoryId == category.Id))
                    checkboxModel.IsSelected = true;

                AvailableCategories.Add(checkboxModel);

                AddToAvailableCategories(category.SubCategories);
            }
        }

        #endregion

        /// <summary>
        /// The select list for the categories
        /// </summary>
        public ICollection<string> SelectedCategoryIds { get; set; } = new List<string>();

        /// <summary>
        /// The select list for the categories
        /// </summary>
        public List<CheckBoxSelectionModel<Category<Event>>> AvailableCategories { get; set; } = new List<CheckBoxSelectionModel<Category<Event>>>();


        /// <summary>
        /// The coverImage of the Blog Post about to be uploaded
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public bool HasCoverUpload => CoverUpload != null;
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();


        /// <summary>
        /// The audio file associated with the blog post about to be uploaded
        /// </summary>
        public IFormFile VideoUpload { get; set; }
        public bool HasVideoUpload => VideoUpload != null;

        /// <summary>
        /// The images of the Post about to be uploaded
        /// </summary>
        public ICollection<IFormFile> ImagesUpload { get; set; } = new List<IFormFile>();
        public bool HasImagesUpload => ImagesUpload.Any();

        /// <summary>
        /// The select list for the categories
        /// </summary>
        public SelectList CategoryList { get; set; }

        /// <summary>
        /// The select list for the sub-categories
        /// </summary>
        public SelectList SubCategoryList { get; set; }
    }
}
