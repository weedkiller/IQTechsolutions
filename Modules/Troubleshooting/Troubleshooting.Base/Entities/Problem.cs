using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Grouping.Base.Entities;
using Iqt.Base.BaseTypes;

namespace Troubleshooting.Base.Entities
{
    /// <summary>
    /// A problem that we are Troubleshooting
    /// </summary>
    public class Problem : EntityBase
    {
        /// <summary>
        /// A description of a problem that may exist, that you are Troubleshooting
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// A description of a problem that may exist, that you are Troubleshooting
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Keywords associated with this problem, used for indexing and searching
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// Flag to indicate if a custom page has been registered and should be used
        /// </summary>
        public bool UseCustomPage { get; set; } = false;

        /// <summary>
        /// A collection of causes for this problem
        /// </summary>
        public ICollection<Cause> Causes { get; set; } = new List<Cause>();

        /// <summary>
        /// A collection of actions to correct the problem
        /// </summary>
        public ICollection<CorrectiveAction> CorrectiveActions { get; set; } = new List<CorrectiveAction>();

        #region Category

        /// <summary>
        /// A list of trouble shooting categories associated with this problem
        /// </summary>
        public ICollection<EntityCategory<Problem>> Categories { get; set; } = new List<EntityCategory<Problem>>();

        #endregion
    }
}