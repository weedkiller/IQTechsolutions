using Blogging.Core.Extensions;
using Feedback.Core.Extensions;
using Filing.Core.Factories;
using Grouping.Core.Extensions;
using Iqt.Base.Interfaces;
using IQTechSolutions.DataStores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IQTechSolutions.Web.Admin
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
            services.AddDbContext<IQTechSolutionsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContext, IQTechSolutionsDbContext>();

            services
                .AddAuthentication(config =>
                {
                    config.DefaultScheme = "CookieAdmin";
                    config.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("CookieAdmin")
                .AddOpenIdConnect("oidc", config =>
                {
                    config.Authority = "https://localhost:4001/";
                    config.ClientId = "Website_Admin";
                    config.ClientSecret = "089e63c9-b451-4a23-8d94-81891cdcfe8d";
                    config.SaveTokens = true;
                    config.ResponseType = "code";
                });

            services.AddTransient<IFileFactory, FileFactory>();
            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();

            services.AddSupportTicketSystem().AddGrouping().AddBlogging();

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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
