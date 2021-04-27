using System.Collections.Generic;
using Employment.Base.Entities;

namespace Employment.Core.Models
{
    /// <inheritdoc />
    /// <summary>
    /// The model for the service index page
    /// </summary>
    public class EmployeeListModel 
    { 
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Default Constructors
        /// </summary>
        /// <param name="collection">The service collection</param>
        /// <param name="size">The page size</param>
        /// <param name="page">The page number</param>
        public EmployeeListModel(ICollection<Employee> collection)
        {
            Employees = collection;
        }

        #endregion        

        #region Service Lists

        /// <summary>
        /// Gets or sets the collection of services
        /// </summary>
        public IEnumerable<Employee> Employees { get; set; }

        #endregion
    }
}