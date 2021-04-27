using System;
using System.Collections.Generic;
using System.Text;

namespace Mailing.Base.Entities
{
    public class EmailDetails
    {
        #region Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="fromName">The name of the sender</param>
        /// <param name="fromEmail">The email address of the sender</param>
        /// <param name="toName">The name of the receiver</param>
        /// <param name="toEmail">The email address of the receiver</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="content">The content of the email</param>
        /// <param name="isHtml">Is the email html compatible</param>
        public EmailDetails(string toName, string toEmail, string subject, string fromName, string fromEmail, string content = null, bool isHtml = true)
        {
            FromName = fromName;
            FromEmail = fromEmail;
            ToName = toName;
            ToEmail = toEmail;
            Subject = subject;
            Content = content;
            IsHtml = isHtml;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The name of the sender
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// The email of the sender
        /// </summary>
        public string FromEmail { get; set; }

        /// <summary>
        /// The name of the receiver
        /// </summary>
        public string ToName { get; set; }

        /// <summary>
        /// The email of the receiver
        /// </summary>
        public string ToEmail { get; set; }

        /// <summary>
        /// The email subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The email body content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Indicates if the contents is a HTML email
        /// </summary>
        public bool IsHtml { get; set; }

        #endregion
    }
}
