using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;
using Newtonsoft.Json;
using Troubleshooting.Entities;

namespace Iqt.Troubleshooting.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// The answers of the faq
    /// </summary>
    public class Answer : EntityBase
    {
        #region Answer

        /// <summary>
        /// The answer to the question
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        [JsonProperty("answer")]
        public string AnswerString { get; set; }

        #endregion

        #region Question

        /// <summary>
        /// The question associated with the answer
        /// </summary>
        [ForeignKey("Question")]
        public string QuestionId { get; set; }
        public Question Question { get; set; }

        #endregion

        public Answer Update(Answer answer)
        {
            AnswerString = answer.AnswerString;
            QuestionId = answer.QuestionId;

            return this;
        }
    }
}