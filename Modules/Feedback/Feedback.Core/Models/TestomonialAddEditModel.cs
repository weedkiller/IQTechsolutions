using Feedback.Base.Entities;
using Filing.Base.Entities;
using Microsoft.AspNetCore.Http;

namespace Feedback.Core.Models
{ 
    /// <summary>
    /// The model used to add or edit a employee entity
    /// </summary>
    public class TestimonialAddEditModel
    {
        #region Constructors

        public TestimonialAddEditModel() { }
        public TestimonialAddEditModel(Testimonial testimonial)
        {
            Testimonial = testimonial;
        }

        #endregion

        /// <summary>
        /// The employee featured by this model
        /// </summary>
        public Testimonial Testimonial { get; set; }

        /// <summary>
        /// The coverImage of the Product about to be uploaded
        /// </summary>
        public IFormFile CoverUpload { get; set; }
        public CropSettings CoverCropSettings { get; set; } = new CropSettings();
    }
}
