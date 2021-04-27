using FeawThings.Web.Datastore;
using Identity.Base.Entities;
using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FeawThings.Web.Identity
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
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;
                })
                .AddEntityFrameworkStores<FeawThingsDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Identity.Cookie";
                config.LoginPath = "/Authentication/Login";
                config.LogoutPath = "/Authentication/Logout";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanViewAdmin", policy => policy.RequireClaim("AdminViewer"));
                options.AddPolicy("CanViewCustomer", policy => policy.RequireClaim("CustomerViewer"));
                options.AddPolicy("CanAdd", policy => policy.RequireClaim("AllowAdditions"));
                options.AddPolicy("CanEdit", policy => policy.RequireClaim("AllowEditions"));
                options.AddPolicy("CanDelete", policy => policy.RequireClaim("AllowDeletions"));
            });

            services
                .AddIdentityServer()
                .AddAspNetIdentity<ApplicationUser>()
                .AddInMemoryIdentityResources(IdentityConfig.IdentityResources)
                .AddInMemoryApiResources(IdentityConfig.ApiResources)
                .AddInMemoryApiScopes(IdentityConfig.ApiScopes)
                .AddInMemoryClients(IdentityConfig.Clients)
                .AddDeveloperSigningCredential();

            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();
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

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
