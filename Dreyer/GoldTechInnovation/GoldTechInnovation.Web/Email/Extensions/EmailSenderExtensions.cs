using Mailing.Base.EmailSenders;
using Mailing.Base.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GoldTechInnovation.Web.Email.Extensions
{
    public static class EmailSenderExtensions
    {
        /// <summary>
        /// Injects the <see cref="EmailTemplateSender"/> into the services to handle the 
        /// <see cref="IEmailTemplateSender"/> service
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomEmailServices(this IServiceCollection services)
        {
            // Inject the SendGridEmailSender
            services.AddTransient<IEmailSender, CustomEmailSender>();
            services.AddTransient<IEmailTemplateSender, EmailTemplateSender>();
            services.AddTransient<DefaultEmailSender>();

            // Return collection for chaining
            return services;
        }
    }
}
