using Education.Base.Entities;
using Iqt.Base.Models;

namespace Education.Core.Models
{
    public class CourseDetailsModel : DetailsModelBase<Course>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="entity">The <see cref="Course"/> that is featured by this model</param>
        public CourseDetailsModel(Course entity) : base(entity)
        {
        }
    }
}
