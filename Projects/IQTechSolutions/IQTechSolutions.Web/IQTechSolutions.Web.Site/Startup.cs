using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Iqt.Base.Interfaces;
using IQTechSolutions.Web.Email;

namespace IQTechSolutions.Web.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAuthentication(config =>
                {
                    config.DefaultScheme = "Cookie";
                    config.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookie")
                .AddOpenIdConnect("oidc", config =>
                {
                    config.Authority = "https://localhost:4001/";
                    config.ClientId = "Website_Public";
                    config.ClientSecret = "c495bd54-4cac-4a48-bc66-d85fca033294";
                    config.SaveTokens = true;
                    config.ResponseType = "code";
                });

            services.AddTransient<DefaultEmailSender>();
            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();

            services.AddHttpClient();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints( endpoints => { endpoints.MapDefaultControllerRoute(); } );
        }
    }
}
