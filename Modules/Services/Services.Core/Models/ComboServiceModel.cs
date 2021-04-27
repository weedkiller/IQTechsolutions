using System.Collections.Generic;
using System.ComponentModel;
using Grouping.Base.Entities;
using Services.Base.Entities;

namespace Services.Core.Models
{
    /// <summary>
    /// The model used when adding a new Combo Category
    /// </summary>
    public class ComboCategoryModel 
    {
        /// <summary>
        /// Gets or sets the selection list for the available categories
        /// </summary>
        public ICollection<Category<Service>> CategoryList { get; set; }

        /// <summary>
        /// Gets or sets the selected category id
        /// </summary>
        [DisplayName("Category")]
        public Category<Service> Category { get; set; }

        /// <summary>
        /// Gets or sets the parent service id
        /// </summary>
        [DisplayName("Service")]
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets the amount of combo services to be included
        /// </summary>
        [DisplayName("Qty")]
        public double Qty { get; set; }
    }
}
