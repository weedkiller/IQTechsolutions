namespace Grouping.Api.Models
{
    public class CategoryResultModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ParentId { get; set; }

        public string DepartmentId { get; set; }

        /// <summary>
        /// The flag to indicate if category is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// The flag to indicate if category is featured
        /// </summary>
        public bool Featured { get; set; }

        public int EntityCount { get; set; }
        public bool HasCollection => EntityCount > 0;

        public int ChildCount { get; set; }
        public bool HasChildren => ChildCount > 0;
    }
}
