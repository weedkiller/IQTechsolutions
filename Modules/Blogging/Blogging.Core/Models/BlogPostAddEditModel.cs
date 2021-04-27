using System.Collections.Generic;
using System.Linq;
using Blogging.Base.Entities;
using Filing.Base.Entities;
using Filing.Base.Extensions;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Http;

namespace Blogging.Core.Models
{
    /// <summary>
    /// The model used when adding a new Product
    /// </summary>
    public class BlogPostAddEditModel : AddEditModelBase<BlogPost>
    {
        #region Constructors   

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BlogPostAddEditModel() : base(new BlogPost()) { }

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor with product parameter
        /// </summary>
        /// <param name="post">The blog post used to constuct the model</param>
        public BlogPostAddEditModel(BlogPost post) : base(post) { }

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor with product parameter
        /// </summary>
        /// <param name="post">The blog post used to constuct the model</param>
        /// <param name="categories">The category list that is available</param>
        public BlogPostAddEditModel(BlogPost post, IEnumerable<Category<BlogPost>> categories) : base(post)
        {
            if (post.Categories != null)
            {
                foreach (var item in post.Categories)
                {
                    SelectedCategoryIds.Add(item.CategoryId);
                }
            }

            AddToAvailableCategories(categories.ToList());
        }

        public void AddToAvailableCategories(ICollection<Category<BlogPost>> list)
        {
            foreach (var category in list)
            {
                var checkboxModel = new CheckBoxSelectionModel<Category<BlogPost>>(category.Id, category.ParentCategoryId, category.Name, category.GetPath(), category.Description);
                if (Entity.Categories.Any(c => c.CategoryId == category.Id))
                    checkboxModel.IsSelected = true;


                if (category.HasSubCategories)
                {
                    AddToAvailableCategoriesChildCollection(category.SubCategories, checkboxModel);
                }
                AvailableCategories.Add(checkboxModel);
            }
        }
        public void AddToAvailableCategoriesChildCollection(ICollection<Category<BlogPost>> list, CheckBoxSelectionModel<Category<BlogPost>> parent)
        {
            foreach (var sub in list)
            {
                var childCheckboxModel = new CheckBoxSelectionModel<Category<BlogPost>>(sub.Id, sub.ParentCategoryId, sub.Name, sub.GetPath(), sub.Description);
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

        public string Author { get; set; }

        /// <summary>
        /// The coverImage of the Blog Post about to be uploaded
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();

        /// <summary>
        /// The audio file associated with the blog post about to be uploaded
        /// </summary>
        public IFormFile AudioUpload { get; set; }

        /// <summary>
        /// The audio file associated with the blog post about to be uploaded
        /// </summary>
        public IFormFile VideoUpload { get; set; }

        /// <summary>
        /// The images of the Post about to be uploaded
        /// </summary>
        public ICollection<IFormFile> ImagesUpload { get; set; } = new List<IFormFile>();

        /// <summary>
        /// The select list for the categories
        /// </summary>
        public ICollection<string> SelectedCategoryIds { get; set; } = new List<string>();

        /// <summary>
        /// The select list for the categories
        /// </summary>
        public List<CheckBoxSelectionModel<Category<BlogPost>>> AvailableCategories { get; set; } = new List<CheckBoxSelectionModel<Category<BlogPost>>>();
    }
}
