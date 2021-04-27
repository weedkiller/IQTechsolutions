using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Education.Base.Entities
{
    /// <summary>
    /// Represents a course a student is registered for
    /// </summary>
    public class StudentCourse
    {
        #region ReadOnly Propterties

        /// <summary>
        /// Gets the Flag to indicate if this student course has already been started
        /// </summary>
        public bool Started => CompletedModules.Any() && CompletedModules.Count > 0 && !Completed;

        /// <summary>
        /// Gets the Flag to indicate if this student course was already completed
        /// </summary>
        public bool Completed => Equals(CompletedModules, Course?.Modules);

        /// <summary>
        /// Gets the completed percentage of the course
        /// </summary>
        public string CompletedPercentage
        {
            get
            {
                if (Course?.Modules == null || CompletedModules == null)
                    return "N/A";
                return ((CompletedModules.Count * 100) / Course.Modules.Count).ToString();
            }
        }

        #endregion

        #region Collections

        /// <summary>
        /// The collection of <see cref="Module"/> already completed
        /// </summary>
        public ICollection<Module> CompletedModules { get; set; }

        /// <summary>
        /// The module id the student is currently working on
        /// </summary>
        public string CurrentModuleId 
        {
            get
            {
                var modules = Course?.Modules.OrderBy(c => c.ModuleNr).ToList();
                if (CompletedModules.Any() && modules.Any())
                {
                    foreach (var module in CompletedModules)
                    {
                        modules.Remove(module);
                    }
                }

                return modules?.FirstOrDefault()?.Id;
            }
        }

        #endregion

        #region Relationships

        /// <summary>
        /// The Student that is registered for this course
        /// </summary>
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        public Student Student { get; set; }

        /// <summary>
        /// The course the student is registered for
        /// </summary>
        [ForeignKey(nameof(Course))]
        public string CourseId { get; set; }
        public Course Course { get; set; }

        #endregion

        
    }
}
