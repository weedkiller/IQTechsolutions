using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Filing.Base.Entities;
using Iqt.Base.BaseTypes;
using Iqt.Base.Enums;
using Iqt.Base.Enums.Support;

namespace Feedback.Base.Entities
{
    /// <summary>
    /// Support ticket for a company that wishes to correspond with customers via support ticket system
    /// </summary>
    public class SupportTicket : EntityBase
    {
        #region Properties
        
        /// <summary>
        /// The subject of this message
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// The content of the message
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        /// <summary>
        /// The email address of the user this ticket belongs to
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The first name of the user this ticket belongs to
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user this ticket belongs to
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The cell nr of the user this ticket belongs to
        /// </summary>
        public string CellNr { get; set; }

        /// <summary>
        /// The priority status of the ticket
        /// </summary>
        public Priority Priority { get; set; } = Priority.Low;

        /// <summary>
        /// The ticket status of the ticket
        /// </summary>
        [DisplayName(@"Ticket Status")]
        public TicketStatus TicketStatus { get; set; }

        /// <summary>
        /// The parent identity of the support ticket this ticket belongs to
        /// </summary>
        public string ParentTicketId { get; set; }
        /// <summary>
        /// The reply to a support ticket
        /// </summary>
        public SupportTicket ParentTicket { get; set; }

        #endregion

        #region Collections

        /// <summary>
        /// The reply to a support ticket
        /// </summary>
        public virtual ICollection<SupportTicket> ChildTickets { get; set; } = new List<SupportTicket>();

        /// <summary>
        /// Any files attached to the ticket
        /// </summary>
        public virtual ICollection<File<SupportTicket>> Files { get; set; } = new List<File<SupportTicket>>();

        #endregion
    }
}
