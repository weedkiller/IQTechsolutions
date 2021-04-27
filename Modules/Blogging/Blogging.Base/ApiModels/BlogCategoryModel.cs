namespace Blogging.Base.ApiModels
{
    public class BlogCategoryModel
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CollectionCount { get; set; }
    }
}
