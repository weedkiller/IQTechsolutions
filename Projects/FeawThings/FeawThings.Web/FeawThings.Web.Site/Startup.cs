using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeawThings.Web.Email;
using FeawThings.Web.Email.Extensions;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Iqt.Base.Interfaces;
using Products.Base.Extensions;

namespace FeawThings.Web.Site
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
                    config.DefaultScheme = "CookieTraining";
                    config.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("CookieTraining")
                .AddOpenIdConnect("oidc", config =>
                {
                    config.Authority = ServerLocations.IdentityServer;
                    config.ClientId = "Website_Training";
                    config.ClientSecret = "1d79825e-31a1-400f-b38d-83f3bac47263";
                    config.SaveTokens = true;
                    config.ResponseType = "code";
                    config.SignedOutCallbackPath = "/Home/Index";
                });

            services.AddProductServices();

            services.AddCustomEmailServices().AddTransient<DefaultEmailSender>();
            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();
            services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
            
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(6);
            });

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
            app.UseSession();

            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}
