using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blogging.Core.Extensions;
using Calendar.Core.Extensions;
using Customers.Core.Extensions;
using Education.Core.Extensions;
using Employment.Core.Extensions;
using Feedback.Core.Extensions;
using Filing.Core.Factories;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Grouping.Core.Extensions;
using Iqt.Base.Interfaces;
using Messaging.Core.Extensions;
using Metsi.Web.Admin.Hubs;
using Metsi.Web.DataStore;
using Metsi.Web.Email;
using Metsi.Web.Email.Extensions;
using Microsoft.EntityFrameworkCore;
using Projects.Core.Extensions;
using Services.Core.Extensions;
using Troubleshooting.Core.Extensions;

namespace Metsi.Web.Admin
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
            services.AddDbContext<MetsiDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContext, MetsiDbContext>();

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
                    config.ClientSecret = "d38a4ad7-2990-4ed0-8889-1f43dea621fc";
                    config.SaveTokens = true;
                    config.ResponseType = "code";
                    config.SignedOutCallbackPath = "/Home/Index";
                });
            
            services.AddTransient<IFileFactory, FileFactory>();
            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();
            services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
            services.AddCustomEmailServices().AddTransient<DefaultEmailSender>();

            services.AddSupportTicketSystem().AddGrouping().AddBlogging().AddFaqs()
                .AddTroubleshooting().AddServiceModule().AddProjects().AddCourses()
                .AddCustomers().AddEmployment().AddMessaging().AddCalender();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSignalR(config => { config.EnableDetailedErrors = true; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzYwNTYyQDMxMzgyZTMzMmUzMG5mMWtqQ3dvQ2xDSEpCNVYrVXd0Y3VxaXNoMm1UTXcrbjNjdHdld0hzMEE9");

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
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("AllowAllOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapHub<NewsFeedHub>("/newsFeedHub");
            });
        }
    }
}
