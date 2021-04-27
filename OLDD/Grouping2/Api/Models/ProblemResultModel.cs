namespace Grouping.Api.Models
{
    /// <summary>
    /// The model used to represent a problem object
    /// </summary>
    public class ProblemResultModel
    {
        /// <summary>
        /// The identity of the problem
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The description of the problem
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// The description of the problem
        /// </summary>
        public string ProblemContent { get; set; }

        /// <summary>
        /// The description of the problem
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// The causes count associated with this problem
        /// </summary>
        public int CausesCount { get; set; }

        /// <summary>
        /// The corrective actions count associated with this problem
        /// </summary>
        public int CorrectiveActionsCount { get; set; }
    }
}
