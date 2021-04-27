using FeawThings.Web.Datastore;
using Filing.Core.Factories;
using Grouping.Core.Extensions;
using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Products.Core.Extensions;

namespace FeawThings.Web.Admin
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
            services.AddDbContext<FeawThingsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContext, FeawThingsDbContext>();

            services
                .AddAuthentication(config =>
                {
                    config.DefaultScheme = "CookieAdmin";
                    config.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("CookieAdmin")
                .AddOpenIdConnect("oidc", config =>
                {
                    config.Authority = ServerLocations.IdentityServer;
                    config.ClientId = "Website_Admin";
                    config.ClientSecret = "88e3ca5b-a99b-47dd-b109-83807a52ad5d";
                    config.SaveTokens = true;
                    config.ResponseType = "code";
                    config.SignedOutCallbackPath = "/Home/Index";
                });

            services.AddTransient<IFileFactory, FileFactory>();
            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();

            services.AddGrouping().AddProducts();

            services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;
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
