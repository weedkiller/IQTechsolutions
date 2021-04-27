using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Filing.Base.Entities;
using Identity.Base.Entities;
using Iqt.Base.BaseTypes;
using Iqt.Base.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Education.Base.Entities
{
    /// <summary>
    /// A employee of this application
    /// </summary>
    public class Student : EntityBase
    {
        public string DisplayName => Names.GetFullNames();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Student()
        {
            Names = new Names();
        }

        /// <summary>
        /// The <see cref="Names"/> of this person
        /// </summary>
        public Names Names { get; set; }
        
        /// <summary>
        /// The bio description of this person
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string PersonalFolder { get; set; }

        /// <summary>
        /// The identity number of the student
        /// </summary>
        public string IdentityNr { get; set; }

        /// <summary>
        /// The flag to indicate if the employee is an active employee
        /// </summary>
        public bool Active { get; set; }
        
        /// <summary>
        /// The <see cref="UserInfo"/> associated with this student
        /// </summary>
        public UserInfo UserInfo { get; set; }

        
        #region Collections

        /// <summary>
        /// The contact numbers for this customer
        /// </summary>
        public ICollection<ContactNumber<Student>> ContactNumbers { get; set; } = new List<ContactNumber<Student>>();

        /// <summary>
        /// Addresses that belongs to this customer
        /// </summary>
        public ICollection<Address<Student>> Addresses { get; set; } = new List<Address<Student>>();

        /// <summary>
        /// Email Addresses that belongs to this customer
        /// </summary>
        public ICollection<EmailAddress<Student>> EmailAddresses { get; set; } = new List<EmailAddress<Student>>();

        /// <summary>
        /// A Collection of courses the student is signed in for
        /// </summary>
        public ICollection<StudentCourse> Courses { get; set; } = new List<StudentCourse>();

        /// <summary>
        /// A list of the students activity on this domain
        /// </summary>
        public ICollection<StudentActivity> Activities { get; set; } = new List<StudentActivity>();
        
        #endregion
    }
}
