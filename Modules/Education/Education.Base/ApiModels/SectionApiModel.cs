namespace Education.Base.ApiModels
{
    /// <summary>
    /// This object is used by the api to return section data
    /// </summary>
    public class SectionApiModel
    {
        /// <summary>
        /// Gets or sets the identity of the parent module or parent section if this is a child section
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets the identity of the featured section
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the section
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the section
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the child section count
        /// </summary>
        public int ChildSectionCount { get; set; }
    }
}
