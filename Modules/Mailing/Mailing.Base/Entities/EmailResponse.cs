using System.Collections.Generic;

namespace Mailing.Base.Entities
{
    /// <summary>
    /// A response from a SendEmail call for any IEmailSender implementation
    /// </summary>
    public class EmailResponse
    {
        /// <summary>
        /// True if the email was sent successfully
        /// </summary>
        public bool Successful => !(Errors?.Count > 0);

        /// <summary>
        /// The error message if the sending failed
        /// </summary>
        public List<string> Errors { get; set; }
    }
}
