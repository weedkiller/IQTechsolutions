using System.Collections.Generic;
using System.ComponentModel;
using Services.Base.Entities;

namespace Services.Core.Models
{
    /// <summary>
    /// The model used when adding a new Combo Category
    /// </summary>
    public class ComboExclusionModel 
    {
        /// <summary>
        /// Gets or sets the selection list for the available categories
        /// </summary>
        public ICollection<Service> ServiceList { get; set; }

        /// <summary>
        /// Gets or sets the selected category id
        /// </summary>
        public Service SelectedService { get; set; }

        /// <summary>
        /// Gets or sets the parent service id
        /// </summary>
        [DisplayName("Category")]
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the parent service id
        /// </summary>
        [DisplayName("Service")]
        public string ServiceId { get; set; }

        public ICollection<Service> Exclusions { get; set; } = new List<Service>();
    }
}
