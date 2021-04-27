using System.Collections.Generic;
using System.Linq;
using Filing.Base.Entities;
using Filing.Base.Extensions;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;
using Projects.Base.Entities;

namespace Projects.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The model used when adding a new Product
    /// </summary>
    public class ProjectAddEditModel : AddEditModelBase<Project>
    {
        #region Constructors   

        public ProjectAddEditModel() : base(new Project()) { }
        public ProjectAddEditModel(Project entity) : base(entity)
        {
        }

        public ProjectAddEditModel(Project entity, IEnumerable<Category<Project>> categories) : base(entity)
        {
            if (entity.Categories != null)
            {
                foreach (var item in entity.Categories)
                {
                    SelectedCategoryIds.Add(item.CategoryId);
                }
            }

            AddToAvailableCategories(categories.ToList());
        }

        public void AddToAvailableCategories(ICollection<Category<Project>> list)
        {
            foreach (var category in list)
            {
                var checkboxModel = new CheckBoxSelectionModel<Category<Project>>(category.Id, category.ParentCategoryId, category.Name, category.GetImage().GetPath(), category.Description);
                if (Entity.Categories.Any(c => c.CategoryId == category.Id))
                    checkboxModel.IsSelected = true;


                if (category.HasSubCategories)
                {
                    AddToAvailableCategoriesChildCollection(category.SubCategories, checkboxModel);
                }
                AvailableCategories.Add(checkboxModel);
            }
        }

        public void AddToAvailableCategoriesChildCollection(ICollection<Category<Project>> list, CheckBoxSelectionModel<Category<Project>> parent)
        {
            foreach (var sub in list)
            {
                var childCheckboxModel = new CheckBoxSelectionModel<Category<Project>>(sub.Id, sub.ParentCategoryId, sub.Name, sub.GetImage().GetPath(), sub.Description);
                if (Entity.Categories.Any(c => c.CategoryId == sub.Id))
                    childCheckboxModel.IsSelected = true;

                parent.ChildSelection.Add(childCheckboxModel);

                if (sub.HasSubCategories)
                {
                    AddToAvailableCategoriesChildCollection(sub.SubCategories, childCheckboxModel);
                }

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
        public List<CheckBoxSelectionModel<Category<Project>>> AvailableCategories { get; set; } = new List<CheckBoxSelectionModel<Category<Project>>>();

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
        /// The banner image of the Product about to be uploaded
        /// </summary>
        public IFormFile SliderUpload { get; set; }

        /// <summary>
        /// The images of the Product about to be uploaded
        /// </summary>
        public ICollection<IFormFile> SliderImagesUpload { get; set; } = new List<IFormFile>();

        /// <summary>
        /// The images of the Product about to be uploaded
        /// </summary>
        public ICollection<IFormFile> ImagesUpload { get; set; } = new List<IFormFile>();

        /// <summary>
        /// The images of the Product about to be uploaded
        /// </summary>
        public ICollection<IFormFile> MockupsUpload { get; set; } = new List<IFormFile>();

        #endregion
    }
}