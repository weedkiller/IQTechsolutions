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
    public class ProblemAddEditModel : AddEditModelBase<Problem>
    {
        #region Constructors

        public ProblemAddEditModel() : base(new Problem()) { }

        /// <inheritdoc />
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="entity">The entity this model should be constructed with</param>
        public ProblemAddEditModel(Problem entity) : base(entity)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Constructor that takes parameter
        /// </summary>
        /// <param name="problem">The product this model is based on</param>
        /// <param name="categories">The category list</param>
        public ProblemAddEditModel(Problem problem, IEnumerable<Category<Problem>> categories) : base(problem)
        {
            Child = "ChildSelection";
            AddToAvailableCategories(categories.ToList());
        }

        public void AddToAvailableCategories(ICollection<Category<Problem>> list)
        {
            foreach (var category in list.OrderByDescending(c => c.SubCategories.Count))
            {
                var checkboxModel = new CheckBoxSelectionModel<Category<Problem>>(category.Id, category.ParentCategoryId, category.Name, category.GetPath(), category.Description);
                if (Entity.Categories.Any(c => c.CategoryId == category.Id))
                    checkboxModel.IsSelected = true;


                if (category.HasSubCategories)
                {
                    AddToAvailableCategoriesChildCollection(category.SubCategories, checkboxModel);
                }
                AvailableCategories.Add(checkboxModel);
            }
        }
        public void AddToAvailableCategoriesChildCollection(ICollection<Category<Problem>> list, CheckBoxSelectionModel<Category<Problem>> parent)
        {
            foreach (var sub in list.OrderByDescending(c => c.SubCategories.Count))
            {
                var childCheckboxModel = new CheckBoxSelectionModel<Category<Problem>>(sub.Id, sub.ParentCategoryId, sub.Name, sub.GetPath(), sub.Description);
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

        public string ReturnUrl { get; set; }

        public ICollection<Category<Problem>> Categories { get; set; }

        public string Child { get; set; }

        /// <summary>
        /// The select list for the categories
        /// </summary>
        public ICollection<string> SelectedCategoryIds { get; set; } = new List<string>();

        /// <summary>
        /// The select list for the categories
        /// </summary>
        public List<CheckBoxSelectionModel<Category<Problem>>> AvailableCategories { get; set; } = new List<CheckBoxSelectionModel<Category<Problem>>>();
    }
}
