using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;
using Iqt.Base.Enums.Personal;

namespace Calendar.Base.Entities
{
    /// <summary>
    /// Event Registration Datatype
    /// </summary>
    public class EventRegistration : EntityBase
    {
        #region Public Members
        
        /// <summary>
        /// Title of the of the Registrar
        /// </summary>
        [DisplayName("Title")]
        public Title Title { get; set; }

        /// <summary>
        /// The firstname of the Registrar
        /// </summary>
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The lastname of the Registrar
        /// </summary>
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// The contact number of the Registrar
        /// </summary>
        [DisplayName("Contact Nr")]
        public string ContactNr { get; set; }

        /// <summary>
        /// The ammount of people that will be attending 
        /// </summary>
        [DisplayName("Amount")]
        public int Attendees { get; set; }

        /// <summary>
        /// The email address of the Registrar
        /// </summary>
        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Any extra notes for the event manager
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        #endregion

        #region Relationships

        [ForeignKey("Event")]
        public string EventId { get; set; }
        public Event Event { get; set; }

        #endregion
    }
}
