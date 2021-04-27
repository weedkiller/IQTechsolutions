using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;

namespace Troubleshooting.Base.Entities
{
    /// <summary>
    /// The cause of a specific problem
    /// </summary>
    public class Cause : EntityBase
    {
        /// <summary>
        /// A description of the cause for the problem
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A list of corrective actions for this specific cause
        /// </summary>
        public ICollection<CorrectiveAction> CorrectiveActions { get; set; } = new List<CorrectiveAction>();

        #region Problem

        /// <summary>
        /// The identity of the problem this cause is associated with
        /// </summary>
        [ForeignKey("Problem")]
        public string ProblemId { get; set; }

        /// <summary>
        /// The problem this cause is associated with
        /// </summary>
        public Problem Problem { get; set; }

        #endregion
    }
}
