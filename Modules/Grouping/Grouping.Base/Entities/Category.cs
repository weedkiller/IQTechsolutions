using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Filing.Base.Entities;
using Iqt.Base.Interfaces;

namespace Grouping.Base.Entities
{
    /// <summary>
    /// A category entity a object can be grouped into
    /// </summary>
    public class Category<T> : ImageFileCollection<Category<T>>, IEntityBase
    {
        #region MyRegion

        /// <summary>
        /// The flag to indicate if category is active
        /// </summary>
        [Display(Name = @"Active")]
        public bool HasSubCategories => SubCategories != null && SubCategories.Any();

        #endregion

        #region Public Properties

        /// <summary>
        /// Name of the Category
        /// </summary>
        [Display(Name = @"Category Name"), Required(ErrorMessage = @"Category Name is Required")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the Category
        /// </summary>
        [Display(Name = @"Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// The flag to indicate if category is active
        /// </summary>
        [Display(Name = @"Active")]
        public bool Active { get; set; } = true;

        /// <summary>
        /// The flag to indicate if category is featured
        /// </summary>
        [Display(Name = @"Featured")]
        public bool Featured { get; set; } = true;

        /// <summary>
        /// A list of web tags for this category
        /// </summary>
        public virtual string WebTags { get; set; }

        #endregion

        #region Parent Category

        /// <summary>
        /// The Parent Category if this is a sub category
        /// </summary>
        [ForeignKey(nameof(ParentCategory))]
        public string ParentCategoryId { get; set; }
        public Category<T> ParentCategory { get; set; }

        /// <summary>
        /// The Parent <see cref="Department"/> of this category if any
        /// </summary>
        [ForeignKey(nameof(Department))]
        public string DepartmentId { get; set; }
        public Department<T> Department { get; set; }

        #endregion

        #region Collection

        /// <summary>
        /// The list of subcategories belonging to this Category
        /// </summary>
        public virtual ICollection<Category<T>> SubCategories { get; set; } = new List<Category<T>>();

        /// <summary>
        /// The courses of this category
        /// </summary>
        public ICollection<EntityCategory<T>> EntityCollection { get; set; } = new List<EntityCategory<T>>();

        #endregion
    }
}
