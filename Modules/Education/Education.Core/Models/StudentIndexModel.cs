using System.Collections.Generic;
using Education.Base.Entities;
using Iqt.Base.Models;

namespace Education.Core.Models
{
    /// <summary>
    /// The <see cref="Student"/> index model
    /// </summary>
    public class StudentIndexModel : IndexModelBase<Student>
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="collection">The student collection featured by this model</param>
        /// <param name="size">The amount of items displayd on a page</param>
        /// <param name="page">The current page number</param>
        /// <param name="sort">The sort order of the list</param>
        public StudentIndexModel(ICollection<Student> collection, int? size = null, int? page = null, int? sort = null) : base(collection, size, page, sort)
        {
        }
    }
}
