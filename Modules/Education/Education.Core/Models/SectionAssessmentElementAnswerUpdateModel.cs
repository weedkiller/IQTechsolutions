using System.ComponentModel;
using Education.Base.Entities;

namespace Education.Core.Models
{
    /// <summary>
    /// Represents the model for the module assessment list
    /// </summary>
    public class SectionAssessmentElementAnswerUpdateModel
    {
        /// <summary>
        /// Gets or sets the identity of the parent Section Id
        /// </summary>  
        public string SectionId { get; set; }

        /// <summary>
        /// The identity of the parent <see cref="AssessmentElement{T}"/>
        /// </summary>
        public string AssessmentElementId { get; set; }

        /// <summary>
        /// Gets or sets the identity of the featured assessment element
        /// </summary>
        public string AssessmentElementAnswerId { get; set; }

        /// <summary>
        /// Gets or sets the answer text
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Gets or sets the is correct flag
        /// </summary>
        [DisplayName("Correct Answer")]
        public bool IsCorrect { get; set; }
    }
}
