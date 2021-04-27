namespace Grouping.Api.Models
{
    /// <summary>
    /// The api result for a problem cause
    /// </summary>
    public class CauseResultModel
    {
        /// <summary>
        /// The identity of the problem cause
        /// </summary>
        public string Id { get; set; }

        public string ParentId { get; set; }

        /// <summary>
        /// The description of the problem cause
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The count of the corrective actions associated with this cause
        /// </summary>
        public int CorrectiveActionsCount { get; set; }
    }
}
