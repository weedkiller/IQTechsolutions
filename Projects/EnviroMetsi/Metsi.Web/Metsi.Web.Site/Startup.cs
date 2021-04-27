using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Iqt.Base.Interfaces;
using Metsi.Web.Email;
using Metsi.Web.Email.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Metsi.Web.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
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
                    config.Authority = ServerLocations.IdentityServer;
                    config.ClientId = "Website_Public";
                    config.ClientSecret = "8768acce-8cc8-4697-8fda-2dcc496d6c72";
                    config.SaveTokens = true;
                    config.ResponseType = "code";
                    config.SignedOutCallbackPath = "/Home/Index";
                });

            services.AddCustomEmailServices().AddTransient<DefaultEmailSender>();
            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();
            services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();


            services.AddHttpClient();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}
