using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Filing.Base.Entities;
using Identity.Base.Entities;
using Iqt.Base.Entities;
using Iqt.Base.Enums.Identity;

namespace Employment.Base.Entities
{
    /// <summary>
    /// A employee of this application
    /// </summary>
    public class Employee : ImageFileCollection<Employee>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Employee()
        {
            Names = new Names();
            SocialMedia = new SocialMedia();
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="applicationAccessLevel">The application level access granted to the user</param>
        /// <param name="employeeType">The employee type</param>
        /// <param name="companyId">The identity of the company this employee works for</param>
        /// <param name="userName">The username this employee uses</param>
        /// <param name="password">The password this employee uses</param>
        public Employee(ApplicationAccessLevel applicationAccessLevel, string companyId, EmployeeType employeeType, string userName = "", string password = null)
        {
            UserName = userName;
            AppPassword = password;
            ApplicationAccessLevel = applicationAccessLevel;
            CompanyId = companyId;
            EmployeeType = employeeType;
        }

        /// <summary>
        /// The <see cref="Names"/> of this person
        /// </summary>
        public Names Names { get; set; }


        /// <summary>
        /// The bio description of this person
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(_description))
                {
                    return Bio;
                }

                return _description;
            }
            set { _description = value; }
        }
        private string _description { get; set; }

        /// <summary>
        /// The bio description of this person
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }

        /// <summary>
        /// The company this employee is associated with
        /// </summary>
        [ForeignKey("Company")]
        public string CompanyId { get; set; }

        /// <summary>
        /// Flag to indicate if this is a featured employee
        /// </summary>
        public bool Featured { get; set; }

        public string WorkTitle { get; set; }

        public bool MarkedForDeletion { get; set; }
        public string IdentityNr { get; set; }
        

        public string DisplayName => Names.GetFullNames();

        /// <summary>
        /// The username used to log into the point of sale
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The authentication token used to stay authenticated through future requests
        /// </summary>
        /// <remarks>The Token is only provided when called from the login methods</remarks>
        public string Token { get; set; }

        /// <summary>
        /// The password used to log into the point of sale
        /// </summary>
        public string AppPassword { get; set; }

        /// <summary>
        /// The Access Level Granted for this user
        /// </summary>
        public ApplicationAccessLevel ApplicationAccessLevel { get; set; }

        /// <summary>
        /// The type of employee this is
        /// </summary>
        public EmployeeType EmployeeType { get; set; }

        public SocialMedia SocialMedia { get; set; }

        /// <summary>
        /// The flag to indicate if the employee is an active employee
        /// </summary>
        public bool Active { get; set; }

        #region Collections

        /// <summary>
        /// The contact numbers for this customer
        /// </summary>
        public ICollection<ContactNumber<Employee>> ContactNumbers { get; set; } = new List<ContactNumber<Employee>>();

        /// <summary>
        /// Addresses that belongs to this customer
        /// </summary>
        public ICollection<Address<Employee>> Addresses { get; set; } = new List<Address<Employee>>();

        /// <summary>
        /// Email Addresses that belongs to this customer
        /// </summary>
        public ICollection<EmailAddress<Employee>> EmailAddresses { get; set; } = new List<EmailAddress<Employee>>();

        /// <summary>
        /// A collection of skills this employee has 
        /// <see cref="Skill"/>
        /// </summary>
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();

        #endregion

        [ForeignKey(nameof(UserInfo))]
        public string UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
