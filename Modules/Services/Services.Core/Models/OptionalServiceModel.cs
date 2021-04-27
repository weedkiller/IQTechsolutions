using System.Collections.Generic;
using System.ComponentModel;
using Grouping.Base.Entities;
using Services.Base.Entities;

namespace Services.Core.Models
{
    /// <summary>
    /// The model used when including a sub-service to a service
    /// </summary>
    public class OptionalServiceModel 
    {
        /// <summary>
        /// Gets or sets the selection list for the categories available
        /// used to filter the service selection list
        /// </summary>
        public ICollection<Category<Service>> CategoryList { get; set; }

        /// <summary>
        /// Gets or sets the selection list for the services available to include in the service
        /// </summary>
        public ICollection<Category<Service>> ServiceList { get; set; }

        /// <summary>
        /// Gets or sets the identity of the selected category
        /// </summary>
        [DisplayName("Category")]
        public Category<Service> Category { get; set; }

        /// <summary>
        /// Gets or sets the identity of the selected service
        /// </summary>
        [DisplayName("Service")]
        public Service Service { get; set; }

        /// <summary>
        /// Gets or sets the identity of the parent service
        /// </summary>
        [DisplayName("Service")]
        public string ParentServiceId { get; set; }

        /// <summary>
        /// Gets or sets the amount of services to be included
        /// </summary>
        [DisplayName("Qty")]
        public double Qty { get; set; }
    }
}
