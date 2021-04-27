using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;

namespace Employment.Base.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// A skill allocated to an entity
    /// </summary>
    public class Skill : EntityBase
    {
        /// <summary>
        /// The name of the skill
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the skill
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///  The skill level/rating
        /// </summary>
        public double Rating { get; set; }

        #region Employee        

        /// <summary>
        /// The identity of the employee this skill belongs to
        /// </summary>
        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }

        /// <summary>
        ///  The employee this skill belongs to
        /// </summary>
        public Employee Employee { get; set; }

        #endregion
    }
}
