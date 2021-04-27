using System.Threading.Tasks;
using Mailing.Base.Entities;

namespace Mailing.Base.Interfaces
{
    /// <summary>
    /// A service that handles sending emails on behalf of the caller
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email message with the given information
        /// </summary>
        /// <param name="details">The details about the email to send</param>
        /// <returns>SendEmailResponse indicating whether it was successfull or not with error messages</returns>
        Task<EmailResponse> SendEmailAsync(EmailDetails details);
    }
}