using Education.Base.Entities;
using Iqt.Base.Models;

namespace Education.Core.Models
{
    /// <summary>
    /// The <see cref="Student"/> details model
    /// </summary>
    public class StudentDetailsModel : DetailsModelBase<Student>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="entity">The <see cref="Student"/> that is featured by this model</param>
        public StudentDetailsModel(Student entity) : base(entity)
        {
        }
    }
}
