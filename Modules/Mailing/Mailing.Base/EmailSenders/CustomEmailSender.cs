using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Mailing.Base.Entities;
using Mailing.Base.Interfaces;

namespace Mailing.Base.EmailSenders
{
    /// <inheritdoc />
    /// <summary>
    /// Sends emails using the SendGrid Service
    /// </summary>
    public class CustomEmailSender : IEmailSender
    {
        public async Task<EmailResponse> SendEmailAsync(EmailDetails details)
        {
            // From
            var from = new MailAddress(details.FromEmail, details.FromName);

            // To
            var to = new MailAddress(details.ToEmail, details.ToName);

            // Subject
            var subject = details.Subject;

            // Content
            var content = details.Content;

            // Create email message
            var msg = new MailMessage(details.FromEmail, details.ToEmail)
            {
                Subject = details.Subject,
                Body = details.Content,
                IsBodyHtml = true

            };
            
            try
            {
                // Create a smtp client
                SmtpClient smtpClient = new SmtpClient("mail.metsi.co.za", 25);
                smtpClient.UseDefaultCredentials = false;

                // Create Nerwork Credentials
                NetworkCredential credentials = new NetworkCredential("donotreply@metsi.co.za", "Is20170804!!");
                
                // Configure smtp client
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                // Finally, send the email...
                await smtpClient.SendMailAsync(msg);

                // Return successful response
                return new EmailResponse();

            }
            catch (Exception ex)
            {
                // Break if we are debugging
                if (Debugger.IsAttached)
                {
                    var error = ex;
                    Debugger.Break();
                }

                // If something unexpected happened, return message
                return new EmailResponse()
                {
                    Errors = new List<string>(new[] { $"Unknown error occurred : {ex.Message}" })
                };
            }
        }
    }
}
