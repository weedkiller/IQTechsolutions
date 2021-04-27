using System.Collections.Generic;
using System.Linq;
using Filing.Base.Entities;
using Filing.Base.Extensions;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;
using Products.Base.Entities;

namespace Products.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The model used when adding a new Product
    /// </summary>
    public class ProductAddEditModel : AddEditModelBase<Product>
    {
        #region Constructors   

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ProductAddEditModel() : base(new Product()) { }

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor with product parameter
        /// </summary>
        /// <param name="product">The product used to constuct the model</param>
        public ProductAddEditModel(Product product) : base(product) { }

        /// <inheritdoc />
        /// <summary>
        /// Constructor that takes parameter
        /// </summary>
        /// <param name="product">The product this model is based on</param>
        /// <param name="categories">The category list</param>
        public ProductAddEditModel(Product product, IEnumerable<Category<Product>> categories) : base(product)
        {
            if (product.Categories != null)
            {
                foreach (var item in product.Categories)
                {
                    SelectedCategoryIds.Add(item.CategoryId);
                }
            }

            AddToAvailableCategories(categories.Where(c => c.ParentCategoryId == null).ToList());
        }

        public void AddToAvailableCategories(ICollection<Category<Product>> list)
        {
            foreach (var category in list)
            {
                var checkboxModel = new CheckBoxSelectionModel<Category<Product>>(category.Id, category.ParentCategoryId, category.Name, category.GetPath(), category.Description);
                if (Entity.Categories.Any(c => c.CategoryId == category.Id))
                    checkboxModel.IsSelected = true;

                AvailableCategories.Add(checkboxModel);

                AddToAvailableCategories(category.SubCategories);
            }
        }

        #endregion

        public string[] WysiwigTools { get; set; } = new[] {
            "Bold", "Italic", "Underline", "StrikeThrough",
            "FontName", "FontSize", "FontColor", "BackgroundColor",
            "LowerCase", "UpperCase", "|",
            "Formats", "Alignments", "OrderedList", "UnorderedList",
            "Outdent", "Indent", "|",
            "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
            "SourceCode", "FullScreen", "|", "Undo", "Redo"
        };

        public string BrandId { get; set; }

        public ICollection<Brand> Brands { get; set; }

        /// <summary>
        /// The select list for the categories
        /// </summary>
        public ICollection<string> SelectedCategoryIds { get; set; } = new List<string>();

        /// <summary>
        /// The select list for the categories
        /// </summary>
        public List<CheckBoxSelectionModel<Category<Product>>> AvailableCategories { get; set; } = new List<CheckBoxSelectionModel<Category<Product>>>();

        /// <summary>
        /// The coverImage of the Product about to be uploaded
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();


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
        public ICollection<IFormFile> ImagesUpload { get; set; } = new List<IFormFile>();
    }
}
