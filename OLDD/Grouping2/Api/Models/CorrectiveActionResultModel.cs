namespace Grouping.Api.Models
{
    /// <summary>
    /// The api result for a corrective action
    /// </summary>
    public class CorrectiveActionResultModel
    {
        /// <summary>
        /// The identity of the corrective action
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the parentId of the corrective action
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// The description of the corrective action 
        /// </summary>
        public string ProblemContent { get; set; }
    }
}
