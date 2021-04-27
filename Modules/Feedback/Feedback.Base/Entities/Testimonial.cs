using System.ComponentModel.DataAnnotations;
using Filing.Base.Entities;

namespace Feedback.Base.Entities
{
    public class Testimonial : ImageFileCollection<Testimonial>
    {
        public string Name { get; set; }

        public string Company { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int Rating { get; set; }
    }
}
