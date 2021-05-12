using System.Collections.Generic;

namespace Services.Base.ApiModels
{
    public class ServiceModel
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<string> Images { get; set; } = new List<string>();

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
