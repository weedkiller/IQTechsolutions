using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Security.Claims;
using Identity.Base.Entities;
using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Metsi.Web.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var applicationConfiguration = scope.ServiceProvider.GetService<IApplicationConfiguration>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

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
                        var d = roleManager.AddClaimAsync(adminRole, new Claim("StudentViewer", "")).Result;
                        var e = roleManager.AddClaimAsync(adminRole, new Claim("EmployeeViewer", "")).Result;
                        var z = roleManager.AddClaimAsync(adminRole, new Claim("AllowAdditions", "")).Result;
                        var a = roleManager.AddClaimAsync(adminRole, new Claim("AllowEditions", "")).Result;
                        var b = roleManager.AddClaimAsync(adminRole, new Claim("AllowDeletions", "")).Result;

                        userManager.AddToRoleAsync(user, adminRole.Name).Wait();
                    }

                    if (!roleManager.RoleExistsAsync("Student").Result)
                    {
                        var studentRole = new IdentityRole()
                        {
                            Name = "Student"
                        };

                        var create = roleManager.CreateAsync(studentRole).Result;

                        var d = roleManager.AddClaimAsync(studentRole, new Claim("StudentViewer", "")).Result;
                    }

                    if (!roleManager.RoleExistsAsync("Employee").Result)
                    {
                        var employeeRole = new IdentityRole()
                        {
                            Name = "Employee"
                        };

                        var create = roleManager.CreateAsync(employeeRole).Result;
                        var d = roleManager.AddClaimAsync(employeeRole, new Claim("EmployeeViewer ", "")).Result;
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
                webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
