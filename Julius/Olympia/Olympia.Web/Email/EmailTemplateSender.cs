using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mailing.Base.Entities;
using Mailing.Base.Interfaces;

namespace Olympia.Web.Email
{
    /// <inheritdoc />
    /// <summary>
    /// Handles sending templated emails
    /// </summary>
    public class EmailTemplateSender : IEmailTemplateSender
    {
        private IEmailSender _sender;

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="sender">The injected email sender</param>
        public EmailTemplateSender(IEmailSender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="details"><see cref="EmailDetails"/>The details of the email</param>
        /// <param name="title">The title of the email</param>
        /// <param name="content1">The first paragraph email content</param>
        /// <param name="content2">The second paragraph email content</param>
        /// <param name="buttonText">The text on the email button</param>
        /// <param name="buttonUrl">The url of the button</param>
        /// <returns>The basic <see cref="EmailResponse"/></returns>
        /// <returns></returns>
        public async Task<EmailResponse> SendGeneralEmailAsync(EmailDetails details, string title, string content1, string content2, string buttonText, string buttonUrl)
        {
            var templateText = default(string);

            // Read the general template from file
            // TODO: Replace with IoC Flat data provider

            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assem => assem.GetName().Name == "Metsi.Web");
            string[] names = assembly.GetManifestResourceNames();

            var stream = assembly.GetManifestResourceStream("Olympia.Web.Email.Templates.GeneralTemplate.htm");

            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                // Read file contents
                templateText = await reader.ReadToEndAsync();
            }

            // Replace special values with those inside the template
            templateText = templateText.Replace("--Title--", title)
                                        .Replace("--Content1--", content1)
                                        .Replace("--Content2--", content2)
                                        .Replace("--ButtonText--", buttonText)
                                        .Replace("--ButtonUrl--", buttonUrl);

            // Set the details content to this template content
            details.Content = templateText;

            try
            {
                return await _sender.SendEmailAsync(details);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            // Send email
            
        }

        /// <summary>
        /// Sends application verification email
        /// </summary>
        /// <param name="details"><see cref="EmailDetails"/>The details of the email</param>
        /// <param name="title">The title of the email</param>
        /// <param name="content1">The email content</param>
        /// <param name="buttonText">The text on the email button</param>
        /// <param name="buttonUrl">The url of the button</param>
        /// <returns>The basic <see cref="EmailResponse"/></returns>
        public async Task<EmailResponse> SendVerificationEmailAsync(EmailDetails details, string title, string content1, string buttonText, string buttonUrl)
        {
            var templateText = default(string);

            // Read the general template from file
            // TODO: Replace with IoC Flat data provider

            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assem => assem.GetName().Name == "Metsi.Web");
            string[] names = assembly.GetManifestResourceNames();

            var stream =
                assembly.GetManifestResourceStream("Olympia.Web.EmailTemplates.VerificationTemplate.htm");

            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                // Read file contents
                templateText = await reader.ReadToEndAsync();
            }

            // Replace special values with those inside the template
            templateText = templateText.Replace("--Title--", title)
                .Replace("--Content1--", content1)
                .Replace("--ButtonText--", buttonText)
                .Replace("--ButtonUrl--", buttonUrl);

            // Set the details content to this template content
            details.Content = templateText;

            // Send email
            return await _sender.SendEmailAsync(details);
        }
        
    }
}