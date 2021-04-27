using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;

namespace Education.Base.Entities
{
    /// <summary>
    /// Represents a multiple answer selection question
    /// </summary>
    public class MultipleChoiceAnswer<T> : EntityBase
    {
        /// <summary>
        /// Gets or sets the answer string
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// The flag to Indicate if this is the correct answer
        /// </summary>
        public bool IsCorrect { get; set; }

        /// <summary>
        /// The parent <see cref="AssessmentElement"/>
        /// </summary>
        [ForeignKey(nameof(AssessmentElement))]
        public string AssessmentElementId { get; set; }
        public AssessmentElement<T> AssessmentElement { get; set; }
    }
}
