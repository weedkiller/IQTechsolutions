using System;
using System.Collections.Generic;

namespace Blogging.Base.ApiModels
{
    public class BlogPostModel
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<string> Images { get; set; } = new List<string>();
        public ICollection<string> Tags { get; set; } = new List<string>();
        public string Title { get; set; }
        public string Content { get; set; }

        public string BlogAuthor { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorDescription { get; set; }

        public string AuthorFacebookUrl { get; set; }
        public string AuthorTwitterUrl { get; set; }
        public string AuthorLinkInUrl { get; set; }
    }
}
