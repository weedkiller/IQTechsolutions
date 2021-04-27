using System.Collections.Generic;
using Education.Base.Entities;

namespace Education.Base.ApiModels
{
    /// <summary>
    /// Api model represents a <see cref="StudentCourse"/>
    /// </summary>
    public class StudentCourseApiModel
    {
        /// <summary>
        /// Gets or Sets the identity of the featured <see cref="Student"/>
        /// </summary>
        public string StudentId { get; set; }

        /// <summary>
        /// Gets or Sets the identity of the featured <see cref="Course"/>
        /// </summary>
        public string CourseId { get; set; }

        /// <summary>
        /// Gets or sets the url of the icon image
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// Gets or sets the url of the cover image
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the amount of modules associated with this course
        /// </summary>
        public int ModulesCount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the completion status
        /// </summary>
        public bool Started { get; set; }

        /// <summary>
        /// Gets or sets the completion percentage of the <see cref="Course"/>
        /// </summary>
        public string CompletedPercentage { get; set; }

        /// <summary>
        /// Gets or sets the collection of completed modules identities associated with this account
        /// </summary>
        public string CurrentModuleId { get; set; }
    }
}
