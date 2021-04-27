using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mailing.Base.Entities;
using Mailing.Base.Interfaces;

namespace FeawThings.Web.Email
{
    /// <inheritdoc />
    /// <summary>
    /// Handles sending templated emails
    /// </summary>
    public class EmailTemplateSender : IEmailTemplateSender
    {
        private IEmailSender _sender;

        public EmailTemplateSender(IEmailSender sender)
        {
            _sender = sender;
        }

        public async Task<EmailResponse> SendGeneralEmailAsync(EmailDetails details, string title, string content1, string content2, string buttonText, string buttonUrl)
        {
            var templateText = default(string);

            // Read the general template from file
            // TODO: Replace with IoC Flat data provider

            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assem => assem.GetName().Name == "FeawThings.Web");
            string[] names = assembly.GetManifestResourceNames();

            var stream = assembly.GetManifestResourceStream("FeawThings.Web.Email.Templates.GeneralTemplate.htm");

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

        public async Task<EmailResponse> SendVerificationEmailAsync(EmailDetails details, string title, string content1, string buttonText, string buttonUrl)
        {
            var templateText = default(string);

            // Read the general template from file
            // TODO: Replace with IoC Flat data provider

            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assem => assem.GetName().Name == "FeawThings.Web");
            string[] names = assembly.GetManifestResourceNames();

            var stream =
                assembly.GetManifestResourceStream("FeawThings.Web.EmailTemplates.VerificationTemplate.htm");

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