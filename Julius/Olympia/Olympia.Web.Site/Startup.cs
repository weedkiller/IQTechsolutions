using System;
using System.Security.Claims;
using Blogging.Core.Extensions;
using Customers.Core.Extensions;
using Employment.Core.Extensions;
using Feedback.Core.Extensions;
using Filing.Core.Factories;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Grouping.Core.Extensions;
using Identity.Base.Entities;
using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Olympia.Web.DataStore;
using Olympia.Web.Email.Extensions;
using Projects.Core.Extensions;
using Services.Core.Extensions;
using Troubleshooting.Core.Extensions;

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
            ConfigureIdentity(services);

            services.AddScoped<DbContext, OlympiaDbContext>();
            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();
            services.AddTransient<IFileFactory, FileFactory>();
            services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
            
            //Add modules to the container
            services.AddCustomEmailServices()
                .AddSupportTicketSystem()
                .AddGrouping()
                .AddBlogging()
                .AddFaqs()
                .AddCustomers()
                .AddEmployment()
                .AddProjects()
                .AddServiceModule();

            services.AddRazorPages();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IApplicationConfiguration appConfiguration)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDM3NzgxQDMxMzkyZTMxMmUzMGtUekU5MGU0NFU4bU5oR1BiK3NxUldYdURJb25tTExYMmxPelM1TFMzTms9");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

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
                    PhoneNumber = appConfiguration.PhoneNr,
                    Email = appConfiguration.AdminEmailAddress,
                    UserInfo = new UserInfo()
                    {
                        Id = id,
                        FirstName = "Administrator",
                        LastName = appConfiguration.CompanyName
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

        private void ConfigureIdentity( IServiceCollection services)
        {
            // AddIdentity adds cookie based authentication
            // Adds scoped classes for things like UserManager, SignInManager, PasswordHashers etc..
            // NOTE: Automatically adds the validated user from a cookie to the HttpContext.User
            // https://github.com/aspnet/Identity/blob/85f8a49aef68bf9763cd9854ce1dd4a26a7c5d3c/src/Identity/IdentityServiceCollectionExtensions.cs
            services.AddIdentity<ApplicationUser, IdentityRole>(config => config.SignIn.RequireConfirmedEmail = false)

                // Adds UserStore and RoleStore from this context
                // That are consumed by the UserManager and RoleManager
                // https://github.com/aspnet/Identity/blob/dev/src/EF/IdentityEntityFrameworkBuilderExtensions.cs
                .AddEntityFrameworkStores<OlympiaDbContext>()

                // Adds a provider that generates unique keys and hashes for things like
                // forgot password links, phone number verification codes etc...
                .AddDefaultTokenProviders();
        }
    }
}
