using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Feedback.Base.Entities;
using Filing.Base.Entities;
using Iqt.Base.Enums;
using Iqt.Base.Enums.Support;
using Microsoft.AspNetCore.Http;

namespace Feedback.Core.Models
{
    /// <summary>
    /// Model used for the update or addition of a support ticket
    /// </summary>
    public class TicketAddEditModel
    {
        #region Properties

        /// <summary>
        /// The identity of the featured entity
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The username of the person posting this ticket
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The firstname of the person posting this ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field")]
        public string FirstName { get; set; }

        /// <summary>
        /// The lastname of the person posting this ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field")]
        public string LastName { get; set; }

        /// <summary>
        /// The email of the person posting this ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field"), EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The phone nr of the person posting this ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field")]
        public string PhoneNr { get; set; }

        /// <summary>
        /// The subject of this support Ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field")]
        public string Subject { get; set; }

        /// <summary>
        /// The content of this support ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        /// <summary>
        /// The status of the ticket
        /// </summary>
        public TicketStatus TicketStatus { get; set; }

        /// <summary>
        /// The priority of the ticket
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        /// The captcha code used to validate the Create Form
        /// </summary>
        public string Captcha{ get; set; }

        /// <summary>
        /// The identity of the parent of this entity
        /// </summary>
        public string ParentId { get; set; }

        #endregion

        #region Collections

        /// <summary>
        /// A collection of files that belongs to this support Ticket
        /// </summary>
        public ICollection<File<SupportTicket>> Files { get; set; }

        /// <summary>
        /// A collection of files for the model, to be uploaded
        /// </summary>
        public ICollection<IFormFile> FilesUpload { get; set; }

        #endregion
    }

    public class TicketModel
    {
        #region Properties

        /// <summary>
        /// The identity of the featured entity
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The username of the person posting this ticket
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The firstname of the person posting this ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field")]
        public string FirstName { get; set; }

        /// <summary>
        /// The lastname of the person posting this ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field")]
        public string LastName { get; set; }

        /// <summary>
        /// The email of the person posting this ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field"), EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The phone nr of the person posting this ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field")]
        public string PhoneNr { get; set; }

        /// <summary>
        /// The subject of this support Ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field")]
        public string Subject { get; set; }

        /// <summary>
        /// The content of this support ticket
        /// </summary>
        [Required(ErrorMessage = "This is a required field")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        /// <summary>
        /// The captcha code used to validate the Create Form
        /// </summary>
        public string Captcha { get; set; }

        #endregion
    }
}
