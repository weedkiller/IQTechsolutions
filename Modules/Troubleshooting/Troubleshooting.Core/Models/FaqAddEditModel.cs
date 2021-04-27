using System.Collections.Generic;
using System.Linq;
using Filing.Base.Extensions;
using Grouping.Base.Entities;
using Iqt.Base.Models;
using Troubleshooting.Base.Entities;

namespace Troubleshooting.Core.Models
{
    /// <summary>
    /// The model used when adding and editing a model
    /// </summary>
    public class FaqAddEditModel : AddEditModelBase<Question>
    {
        #region Constructors

        public FaqAddEditModel() : base(new Question()) { }

        /// <inheritdoc />
        /// <summary>
        /// Constructor that takes parameter
        /// </summary>
        /// <param name="problem">The problem this model is based on</param>
        /// <param name="categories">The category list</param>
        public FaqAddEditModel(Question problem, IEnumerable<Category<Question>> categories) : base(problem)
        {
            if (problem.Categories != null)
            {
                foreach (var item in problem.Categories)
                {
                    SelectedCategoryIds.Add(item.CategoryId);
                }
            }

            AddToAvailableCategories(categories.ToList());
        }

        /// <summary>
        /// Add the categories to the available category list
        /// </summary>
        /// <param name="list"></param>
        public void AddToAvailableCategories(ICollection<Category<Question>> list)
        {
            foreach (var category in list)
            {
                var checkboxModel = new CheckBoxSelectionModel<Category<Question>>(category.Id, category.ParentCategoryId, category.Name, category.GetPath(), category.Description);
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
        public List<CheckBoxSelectionModel<Category<Question>>> AvailableCategories { get; set; } = new List<CheckBoxSelectionModel<Category<Question>>>();
    }
}
