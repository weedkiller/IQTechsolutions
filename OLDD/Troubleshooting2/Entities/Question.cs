using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Grouping.Entities;
using Iqt.Filing.Entities;
using Iqt.Troubleshooting.Entities;

namespace Troubleshooting.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The frequently asked questions of this application
    /// </summary>
    public class Question : ImageFileCollection<Question>
    {
        #region Questions

        /// <summary>
        /// The Question
        /// </summary>
        [Required]
        public string QuestionString { get; set; }

        /// <summary>
        /// The collection of tags associated with this faq
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// The user that added this question
        /// </summary>
        public string ApplicationUserId { get; set; }

        #endregion

        #region Answers

        /// <summary>
        /// The collection of answers
        /// </summary>
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

        /// <summary>
        /// A collection of Frequently Asked Question Categories
        /// </summary>
        public ICollection<EntityCategory<Question>> Categories { get; set; } = new List<EntityCategory<Question>>();

        #endregion
    }
}