using System.Collections.Generic;
using Education.Base.Entities;
using Iqt.Base.Models;

namespace Education.Core.Models
{
    public class CourseIndexModel : IndexModelBase<Course>
    {
        public CourseIndexModel(ICollection<Course> collection, int? size = null, int? page = null, int? sort = null) : base(collection, size, page, sort)
        {
        }
    }
}
