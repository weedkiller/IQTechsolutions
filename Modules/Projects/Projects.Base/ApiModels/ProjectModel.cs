using System;
using System.Collections.Generic;

namespace Projects.Base.ApiModels
{
    /// <summary>
    /// Represents and api model for projects
    /// </summary>
    public class ProjectModel
    {
        /// <summary>
        /// Gets or sets the identity of the project
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date the project was started
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the date the project was completed
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the project
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the url of the project if any
        /// </summary>
        public string ProjectUrl { get; set; }

        /// <summary>
        /// Gets or sets the url of the cover image
        /// </summary>
        public string CoverImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the description of the project
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the collection of image urls
        /// </summary>
        public ICollection<string> Images { get; set; } = new List<string>();
    }
}
