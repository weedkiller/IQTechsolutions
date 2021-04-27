using System;
using System.ComponentModel.DataAnnotations;
using Iqt.Base.BaseTypes;

namespace Education.Base.Entities
{
    public class StudentActivity : EntityBase
    {
        /// <summary>
        /// The description of the activity
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The time the activity was started
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The time the activity was ended
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Any comments associated with this activity
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        #region Relationships

        /// <summary>
        /// The student this activity belongs to
        /// </summary>
        public string StudentId { get; set; }
        public Student Student { get; set; }

        #endregion
    }
}
