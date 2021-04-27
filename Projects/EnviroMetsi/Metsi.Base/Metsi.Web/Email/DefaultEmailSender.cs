using System.Threading.Tasks;
using Iqt.Base.Interfaces;
using Mailing.Base.Entities;
using Mailing.Base.Interfaces;

namespace Metsi.Web.Email
{
    /// <summary>
    /// Handles sending emails specific to the server
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
            return await _emailTemplateSender.SendGeneralEmailAsync(new EmailDetails(displayName, email, "Verify Your Email", _applicationConfiguration.CompanyName + " Website Administration", _applicationConfiguration.AdminEmailAddress),
                "Verify Email",
                $"Hi {displayName ?? "stranger"},",
                "Thanks for creating an account with us.<br/>To continue please verify your email with us.",
                "Verify Email",
                verificationUrl
            );
        }

        public async Task<EmailResponse> SendTestimonialRequestUserEmailAsync(string displayName, string email, string verificationUrl)
        {
            return await _emailTemplateSender.SendGeneralEmailAsync(new EmailDetails(displayName, email, "Please Complete this optional Survey for Enviro Metsi", _applicationConfiguration.CompanyName + " Website Administration", _applicationConfiguration.AdminEmailAddress),
                "Please Complete this optional Survey!",
                $"Hi {displayName ?? "Dear Customer"},",
                "We wanted to reach out to let you know that it was a pleasure working with you, we truly appreciate you and your team.<br/><br/>" +
                "When we complete projects with terrific clients, we like to finnish up with a testimonial feature on our website. We were wondering " +
                "if you'd be willing to share your thoughts on our recent projects so we can add it to the website. You can see examples of previous features" +
                "on <a href='http://www.metsi.co.za'>www.metsi.co.za</a>.<br/><br/>" +
                "You can submit your testimonial if you follow the link below on your laptop, computer or smart phone, and enter a few details about " +
                "the services we offered and your experience working with us.<br/><br/>" +
                "Again it has been a pleasure working with you and your team.<br/><br/>" +
                "Best Regards The Enviro Metsi Team",
                "Complete our optional survey!",
                verificationUrl
            );
        }

        public  async Task<EmailResponse> SendTestimonialCreatedUserEmailAsync(string displayName, string email, string verificationUrl)
        {
            return await _emailTemplateSender.SendGeneralEmailAsync(new EmailDetails(displayName, email, "Thank You for Completing the Enviro Metsi Survey", _applicationConfiguration.CompanyName + " Website Administration", _applicationConfiguration.AdminEmailAddress),
                "Thank your for Completing our Survey",
                $"Hi {displayName ?? "Dear Customer"},",
                "Thank you for completing the survey we really truly appreciate the time and honesty. Have an awesome day",
                "www.metsi.co.za",
                verificationUrl
            );
        }

        public async Task<EmailResponse> SendTestimonialCreatedAdminEmailAsync(string displayName, string email, string verificationUrl, string companyName, string phoneNr, string designation, string score1, string score2, string score3, string score4, string score5, string answer1, string answer2)
        {
            return await _emailTemplateSender.SendGeneralEmailAsync(new EmailDetails(_applicationConfiguration.CompanyName + " Website Administration", _applicationConfiguration.AdminEmailAddress, $"{displayName} completed a survey", _applicationConfiguration.CompanyName + " Website Administration", _applicationConfiguration.AdminEmailAddress),
                $"{displayName} just completed a survey that is waiting approval!",
                $"Hi {displayName ?? "Enviro Metsi Admin"},",
                $"A survey with the following details was completed by {displayName}<br/><br/>" +
                $"<strong>Company Name</strong> : {companyName}<br/>" +
                $"<strong>Designation</strong> : {designation}<br/>" +
                $"<strong>Email</strong> : {email}<br/>" +
                $"<strong>Phone Nr</strong> : {phoneNr}<br/>" +
                $"<strong>Did we perform the correct analysis in terms of what was requested / Water Quality Standards / Requirements / Globalgap, etc.or explain deviations ?</strong> : Score - {score1}<br/><br/>" +
                $"<strong>How well do you think we understand your analytical needs In terms of the above ?</strong> : Score - {score2}<br/><br/>" +
                $"<strong>Is the price fair for the quality of accredited work performed, turn-around time/delivery of results or time spent discussing results and advice supplied ?</strong> : Score - {score3}<br/><br/>" +
                $"<strong>Speed of delivery of results/within agreed times (within 2 days - on time) ?</strong> : Score - {score4}<br/><br/>" +
                $"<strong>How do you perceive the quality of the results. (Do you trust our results) ?</strong> : Score - {score5}<br/><br/><br/>" +
                $"<strong>Would you make use of our services again?</strong> : {answer1}<br/><br/>" +
                $"<strong>Would you like someone from Enviro Metsi to contact you to discuss your requirements or problems that you experienced ? </strong> : {answer2}<br/><br/>",
                "www.metsi.co.za",
                verificationUrl
            );
        }

        public async Task<EmailResponse> SendEmployeeRegistrationEmailAsync(string displayName, string email, string callbackUrl, string username, string password)
        {
            return await _emailTemplateSender.SendGeneralEmailAsync(new EmailDetails(displayName, email, "You have been registered as an employee at Enviro Metsi", _applicationConfiguration.CompanyName + " Website Administration", _applicationConfiguration.AdminEmailAddress),
                "Employee registration mail",
                $"Hi {displayName ?? "stranger"},",
                "<h4>Your Credentials are:</h4><br/><br/>" +
                $"<strong>Username : </strong>{username}<br/><br/>" +
                $"<strong>Password : </strong>{password}<br/><br/>" ,
                "Profile",
                callbackUrl
            );
        }

        public async Task<EmailResponse> SendStudentRegistrationEmailAsync(string displayName, string email, string callbackUrl, string username, string password)
        {
            return await _emailTemplateSender.SendGeneralEmailAsync(new EmailDetails(displayName, email, "Please register on our training website for you credentials", _applicationConfiguration.CompanyName + " Website Administration", _applicationConfiguration.AdminEmailAddress),
                "Please register on our website",
                $"Hi {displayName ?? "stranger"},",
                "<p>Please register on our training website to create you profile and sign in credentials.</p>",
                "Register Now",
                callbackUrl
            );
        }

        /// <summary>
        /// Sends a verification email to the user that logged a support ticket
        /// </summary>
        /// <param name="displayName">The users display name (typically first name)</param>
        /// <param name="email">The users email to be verified</param>
        /// <param name="verificationUrl">The URL the user needs to click to verify their email</param>
        /// <returns></returns>
        public async Task<EmailResponse> SendUserSupportTicketEmailAsync(string displayName, string email, string verificationUrl)
        {
            return await _emailTemplateSender.SendGeneralEmailAsync(new EmailDetails(displayName, email, $"Thank You for submitting a support reqeust - {_applicationConfiguration.CompanyName} Website Administration", _applicationConfiguration.CompanyName + " Website Administration", _applicationConfiguration.AdminEmailAddress),
                "Thank You",
                $"Hi {displayName ?? "stranger"},",
                $"Thank you for submitting a support reqeust with us.<br/> A {_applicationConfiguration.CompanyName} service representative will get back to you shortly.",
                "Go To HomePage",
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
        public async Task<EmailResponse> SendAdminSupportTicketEmailAsync(string displayName, string subject, string cell, string details, string email, string verificationUrl)
        {
            return await _emailTemplateSender.SendGeneralEmailAsync(new EmailDetails(displayName, _applicationConfiguration.AdminEmailAddress, $"Support Ticket {_applicationConfiguration.CompanyName} Website Administration from {displayName}", email, displayName),
                $"Support Ticket Submitted by {displayName}",
                "Hi Administrator,",
                $"{displayName} submitted a support request with the following details.<br/>" +
                $"<strong>Subject : </strong> {subject}.<br/> " +
                $"<strong>Email : </strong> {email}.<br/> " +
                $"<strong>Telephone : </strong> {cell}.<br/> " +
                $"<strong>Details : </strong> {details}.",
                "Go to Home Page",
                verificationUrl
            );
        }

        public async Task<EmailResponse> SendSharedUserFolderEmailAsync(string displayName, string folderName, string email, string verificationUrl)
        {
            return await _emailTemplateSender.SendGeneralEmailAsync(new EmailDetails(displayName, _applicationConfiguration.AdminEmailAddress, $"Support Ticket {_applicationConfiguration.CompanyName} Website Administration from {displayName}", email, displayName),
                $"Support Ticket Submitted by {displayName}",
                "Hi Administrator,",
                $"Folder {folderName} has been shared with you",
                "Go to Home Page",
                verificationUrl
            );
        }
    }
}