using Grouping.Base.Entities;
using Iqt.Base.BaseTypes;
using Iqt.Base.Models;

namespace Grouping.Core.Models
{
    /// <summary>
    /// Model for <see cref="Department{T}"/> Details page
    /// </summary>
    /// <typeparam name="T">The <see cref="Department{T}"/> type featured</typeparam>
    public class DepartmentDetailsModel<T> : DetailsModelBase<Department<T>> where T : EntityBase, new()
    {
        /// <summary>
        /// The default Constructor
        /// </summary>
        /// The<see cref="Department{T}"/> type featured
        public DepartmentDetailsModel(Department<T> entity) : base(entity)
        {
        }
    }
}