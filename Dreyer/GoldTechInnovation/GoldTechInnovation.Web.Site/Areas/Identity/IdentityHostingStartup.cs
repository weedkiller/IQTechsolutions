using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(GoldTechInnovation.Web.Site.Areas.Identity.IdentityHostingStartup))]
namespace GoldTechInnovation.Web.Site.Areas.Identity
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