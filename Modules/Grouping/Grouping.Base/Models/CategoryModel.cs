namespace Grouping.Base.Models
{
    public class CategoryModel
    {
        public CategoryModel(){}

        public CategoryModel(string id, string imageUrl, string name, string description, int childCategoryCount, int entityCategoryCount)
        {
            Id = id;
            ImageUrl = imageUrl;
            Name = name;
            Description = description;
            ChildCategoryCount = childCategoryCount;
            EntityCategoryCount = entityCategoryCount;
        }

        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ChildCategoryCount { get; set; }
        public int EntityCategoryCount { get; set; }
    }
}
