using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(KingdomLifestyleMinistries.Web.Site.Areas.Identity.IdentityHostingStartup))]
namespace KingdomLifestyleMinistries.Web.Site.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}