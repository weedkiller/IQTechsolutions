namespace Education.Base.ApiModels
{
    /// <summary>
    /// This object is used by the api to return module data
    /// </summary>
    public class ModuleApiModel
    {
        /// <summary>
        /// Gets or sets the identity of the parent course
        /// </summary>
        public string CourseId { get; set; }

        /// <summary>
        /// Gets or sets the identity of the featured module
        /// </summary>
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the name of the module
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the module
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the child section count
        /// </summary>
        public int SectionCount { get; set; }
    }
}
