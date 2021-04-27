using System.Collections.Generic;
using Education.Base.Entities;

namespace Education.Core.Models
{
    /// <summary>
    /// Represents the model for the section assessment list
    /// </summary>
    public class SectionAssessmentElementAnswerListModel
    {
        /// <summary>
        /// The identity of the parent <see cref="AssessmentElement{T}"/>
        /// </summary>
        public string AssessmentElementId { get; set; }

        /// <summary>
        /// The identity of the section that the assessment element belongs tos
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// The collection of featured answers
        /// </summary>
        public IEnumerable<MultipleChoiceAnswer<Section>> Answers { get; set; } = new List<MultipleChoiceAnswer<Section>>();
    }
}
