using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Iqt.Filing.Entities;

namespace Grouping.Entities
{
    /// <summary>
    /// Represents the department categories is grouped into
    /// </summary>
    public class Department<T> : ImageFileCollection<Department<T>>
    {
        /// <summary>
        /// Gets or Sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets the categories that belongs to this department
        /// </summary>
        public ICollection<Category<T>> Categories { get; set; } = new List<Category<T>>();
    }
}
