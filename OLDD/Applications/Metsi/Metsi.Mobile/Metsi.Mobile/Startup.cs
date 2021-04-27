using System;
using System.Reflection;
using Iqt.Base.Interfaces;
using Metsi.Mobile.Services;
using Metsi.Mobile.Services.Navigation;
using Metsi.Mobile.Services.Settings;
using Metsi.Mobile.ViewModels.Application;
using Metsi.Mobile.ViewModels.Authentication;
using Metsi.Mobile.ViewModels.Chat;
using Metsi.Mobile.ViewModels.Faqs;
using Metsi.Mobile.ViewModels.Support;
using Metsi.Mobile.ViewModels.Troubleshooting;
using Metsi.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xamarin.Essentials;

namespace Metsi.Mobile
{
    /// <summary>
    /// Startup class for the mobile application
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Gets or Sets the service Provider
        /// </summary>
        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// Initializes and registers the Service Provider with the mobile application
        /// </summary>
        public static void Init()
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("Metsi.Mobile.appsettings.json");

            var host = new HostBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    // Tell the host configuration where to file the file (this is required for Xamarin apps)
                    c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });

                    //read in the configuration file!
                    c.AddJsonStream(stream);
                })
                .ConfigureServices((c, x) =>
                {
                    // Configure our local services and access the host configuration
                    ConfigureServices(c, x);
                })
                .ConfigureLogging(l => l.AddConsole(o =>
                {
                    //setup a console logger and disable colors since they don't have any colors in VS
                    o.DisableColors = true;
                }))
                .Build();

            //Save our service provider so we can use it later.
            ServiceProvider = host.Services;
        }

        /// <summary>
        /// Configures services and objects and registers them with the dependency container
        /// </summary>
        /// <param name="ctx">The injected <see cref="HostBuilderContext"/></param>
        /// <param name="services">The injected <see cref="IServiceCollection"/></param>
        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IApplicationConfiguration, ApplicationConfiguration>();

            services.AddTransient<ISettingsService, SettingsService>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<ContactUsViewModel>();
            services.AddTransient<CommingSoonViewModel>();
            services.AddTransient<SettingViewModel>();
            services.AddTransient<FAQViewModel>();

            services.AddTransient<ProblemCategoryListViewModel>();
            services.AddTransient<ProblemCategoryDetailsViewModel>();
            services.AddTransient<ProblemDetailsViewModel>();
            services.AddTransient<ProblemCauseDetailsViewModel>();
            services.AddTransient<CorrectiveActionDetailsViewModel>();
            
            services.AddTransient<RecentChatViewModel>();

        }
    }
}
