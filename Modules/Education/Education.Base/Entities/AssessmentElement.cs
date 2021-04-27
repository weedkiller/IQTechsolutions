using System.Collections.Generic;
using Iqt.Base.Entities;

namespace Education.Base.Entities
{
    /// <summary>
    /// Class representing a assessment element
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AssessmentElement<T> : FormElement<T>
    {
        /// <summary>
        /// The point allocation for this assessment item
        /// </summary>
        public int PointAllocation { get; set; } = 1;

        #region Collection

        /// <summary>
        /// The collection of multi-choice answers
        /// </summary>
        public ICollection<MultipleChoiceAnswer<T>> Answers { get; set; } = new List<MultipleChoiceAnswer<T>>();

        #endregion
    }
}
