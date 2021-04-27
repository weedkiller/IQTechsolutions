using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;

namespace Troubleshooting.Base.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// A corrective action to take to solve a problem
    /// </summary>
    public class CorrectiveAction : EntityBase
    {
        /// <summary>
        /// A description of a corrective action for a Troubleshooting problem and cause
        /// </summary>
        public string Description { get; set; }

        #region Cause

        /// <summary>
        /// The identity of the cause associated with this corrective action
        /// </summary>
        [ForeignKey("Cause")]
        public string CauseId { get; set; }

        /// <summary>
        /// The cause associated with this corrective action
        /// </summary>
        public Cause Cause { get; set; }

        #endregion

        #region Problem

        /// <summary>
        /// The identity of the problem associated with this corrective action
        /// </summary>
        [ForeignKey("Problem")]
        public string ProblemId { get; set; }

        /// <summary>
        /// The problem associated with this corrective action
        /// </summary>
        public Problem Problem { get; set; }

        #endregion
    }
}