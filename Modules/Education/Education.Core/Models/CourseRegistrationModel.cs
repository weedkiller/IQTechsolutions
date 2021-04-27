using System.Collections.Generic;
using Education.Base.Entities;
using Iqt.Base.Models;

namespace Education.Core.Models
{
    public class CourseRegistrationModel
    {
        public string StudentId { get; set; }

        public List<CheckBoxSelectionModel<Course>> AvailableCourses { get; set; } = new List<CheckBoxSelectionModel<Course>>();
    }
}
