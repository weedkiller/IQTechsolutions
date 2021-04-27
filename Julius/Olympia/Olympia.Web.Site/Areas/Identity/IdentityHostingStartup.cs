using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Olympia.Web.Site.Areas.Identity.IdentityHostingStartup))]
namespace Olympia.Web.Site.Areas.Identity
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