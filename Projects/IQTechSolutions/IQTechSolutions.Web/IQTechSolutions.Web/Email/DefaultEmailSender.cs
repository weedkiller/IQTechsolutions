using System.Threading.Tasks;
using Iqt.Base.Interfaces;
using Mailing.Base.Entities;
using Mailing.Base.Interfaces;

namespace IQTechSolutions.Web.Email
{
    /// <summary>
    /// Handles sending emails specific to the Fasetto Word server
    /// </summary>
    public class DefaultEmailSender
    {
        private IEmailTemplateSender _emailTemplateSender;
        private IApplicationConfiguration _applicationConfiguration;

        public DefaultEmailSender(IEmailTemplateSender emailTemplateSender, IApplicationConfiguration applicationConfiguration)
    {
        _emailTemplateSender = emailTemplateSender;
        _applicationConfiguration = applicationConfiguration;
    }


        /// <summary>
    /// Sends a verification email to the specified user
    /// </summary>
    /// <param name="displayName">The users display name (typically first name)</param>
    /// <param name="email">The users email to be verified</param>
    /// <param name="verificationUrl">The URL the user needs to click to verify their email</param>
    /// <returns></returns>
        public async Task<EmailResponse> SendUserVerificationEmailAsync(string displayName, string email, string verificationUrl)
    {
        return await _emailTemplateSender.SendGeneralEmailAsync(
            new EmailDetails(displayName, email, "Please Verify Your Email Address", $"{_applicationConfiguration.CompanyName} Website Administration",
                _applicationConfiguration.EmailAddress),
            "Verify Email",
            $"Hi {displayName ?? "stranger"},",
            "Thanks for creating an account with us.<br/>To continue please verify your email with us.",
            "Verify Email",
            verificationUrl
        );
    }

        /// <summary>
    /// Sends a verification email to the specified user
    /// </summary>
    /// <param name="displayName">The users display name (typically first name)</param>
    /// <param name="email">The users email to be verified</param>
    /// <param name="verificationUrl">The URL the user needs to click to verify their email</param>
    /// <param name="password"></param>
    /// <returns></returns>
        public async Task<EmailResponse> SendWelcomeCustomerEmailAsync(string displayName, string email,
            string verificationUrl, string password)
    {
        return await _emailTemplateSender.SendGeneralEmailAsync(
            new EmailDetails(displayName, email, $"You have been registered as a valued Customer at {_applicationConfiguration.CompanyName}", $"{_applicationConfiguration.CompanyName} Website Admin",
                _applicationConfiguration.EmailAddress),
            "Welcome Email",
            $"Hi {displayName ?? "stranger"},",
            "You have been registered as a valued customer at IQ Tech Solutions. Thanks you for doing business with you.<br/> " +
            $"You can use the bottom link to go to the login screen of your account.<br/> Your password is : <strong>{password}</strong>",
            "Welcome to the IQ Tech Solutions Family",
            verificationUrl
        );
    }

        /// <summary>
    /// Sends a verification email to the user that logged a support ticket
    /// </summary>
    /// <param name="displayName">The users display name (typically first name)</param>
    /// <param name="email">The users email to be verified</param>
    /// <param name="verificationUrl">The URL the user needs to click to verify their email</param>
    /// <returns></returns>
        public async Task<EmailResponse> SendUserSupportTicketEmailAsync(string displayName, string email,
            string verificationUrl)
    {
        return await _emailTemplateSender.SendGeneralEmailAsync(
            new EmailDetails(displayName, email, $"Thank You for submitting a support request to {_applicationConfiguration.CompanyName}", $"{_applicationConfiguration.CompanyName} Website Administration",
                _applicationConfiguration.EmailAddress), 
            "Thank You",
            $"Hi {displayName ?? "stranger"},",
            $"Thank you for submitting a support request with us.<br/> A {_applicationConfiguration.CompanyName} service representative will get back to you shortly.",
            "Open Support Ticket",
            verificationUrl
        );
    }

        /// <summary>
    /// Sends a verification email to the user that logged a support ticket
    /// </summary>
    /// <param name="displayName">The users display name (typically first name)</param>
    /// <param name="details"></param>
    /// <param name="email">The users email to be verified</param>
    /// <param name="verificationUrl">The URL the user needs to click to verify their email</param>
    /// <param name="subject"></param>
    /// <param name="cell"></param>
    /// <returns></returns>
        public async Task<EmailResponse> SendAdminSupportTicketEmailAsync(string displayName, string subject,
            string cell, string details, string email, string verificationUrl)
    {
        return await _emailTemplateSender.SendGeneralEmailAsync(
            new EmailDetails(displayName, _applicationConfiguration.EmailAddress, $"Support Ticket IQ Tech Solutions from {displayName}", $"{_applicationConfiguration} Website Administration",
                _applicationConfiguration.EmailAddress),
            $"Support Ticket Submitted by {displayName}",
            "Hi Administrator,",
            $"{displayName} submitted a support request with the following details.<br/>" +
            $"<strong>Subject : </strong> {subject}.<br/> " +
            $"<strong>Email : </strong> {email}.<br/> " +
            $"<strong>Telephone : </strong> {cell}.<br/> " +
            $"<strong>Details : </strong> {details}.",
            "Go to Support Ticket",
            verificationUrl
        );
    }
    }
}
