using System;
using System.Security.Claims;
using Blogging.Core.Extensions;
using Feedback.Core.Extensions;
using Filing.Core.Factories;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Grouping.Core.Extensions;
using Identity.Base.Entities;
using Iqt.Base.Interfaces;
using Metsi.Web.Email;
using Metsi.Web.Email.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Olympia.Web.Datastore;

namespace Olympia.Web.Site
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
            services.AddDbContext<OlympiaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<DbContext, OlympiaDbContext>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<OlympiaDbContext>();

            services.AddTransient<IFileFactory, FileFactory>();
            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();
            services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
            services.AddCustomEmailServices().AddSupportTicketSystem().AddGrouping().AddBlogging(); ;

            services.AddRazorPages();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IApplicationConfiguration applicationConfiguration)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzYwNTYyQDMxMzgyZTMzMmUzMG5mMWtqQ3dvQ2xDSEpCNVYrVXd0Y3VxaXNoMm1UTXcrbjNjdHdld0hzMEE9");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            if (userManager.FindByNameAsync("Administrator").Result == null)
            {
                var id = Guid.NewGuid().ToString();
                ApplicationUser user = new ApplicationUser()
                {
                    Id = id,
                    UserName = "Administrator",
                    PhoneNumber = applicationConfiguration.PhoneNr,
                    Email = applicationConfiguration.AdminEmailAddress,
                    UserInfo = new UserInfo()
                    {
                        Id = id,
                        FirstName = "Administrator",
                        LastName = applicationConfiguration.CompanyName
                    }
                };
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Adm1n@Passw0rd").Result;

                if (!roleManager.RoleExistsAsync("Admin").Result)
                {
                    var adminRole = new IdentityRole()
                    {
                        Name = "Admin"
                    };

                    var create = roleManager.CreateAsync(adminRole).Result;

                    var x = roleManager.AddClaimAsync(adminRole, new Claim("AdminViewer", "")).Result;
                    var d = roleManager.AddClaimAsync(adminRole, new Claim("CustomerViewer", "")).Result;
                    var z = roleManager.AddClaimAsync(adminRole, new Claim("AllowAdditions", "")).Result;
                    var a = roleManager.AddClaimAsync(adminRole, new Claim("AllowEditions", "")).Result;
                    var b = roleManager.AddClaimAsync(adminRole, new Claim("AllowDeletions", "")).Result;

                    userManager.AddToRoleAsync(user, adminRole.Name).Wait();
                }

                if (!roleManager.RoleExistsAsync("Customer").Result)
                {
                    var studentRole = new IdentityRole()
                    {
                        Name = "Customer"
                    };

                    var create = roleManager.CreateAsync(studentRole).Result;

                    var d = roleManager.AddClaimAsync(studentRole, new Claim("CustomerViewer", "")).Result;
                }
            }
        }
    }
}
