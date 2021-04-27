using Iqt.Base.Interfaces;
using Iqt.Grouping.Data;
using Iqt.Grouping.Interfaces;
using Iqt.Grouping.Services;
using Iqt.Troubleshooting.Data;
using Metsi.Web.DataStore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Metsi.Web.Api
{
    public class Startup
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="configuration">The injected IConfiguration</param>
        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        /// <summary>
        /// The application configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by runtime. Adds services to the <see cref="ServiceCollection"/>
        /// </summary>
        /// <param name="services">The injected service collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MetsiDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDbContext>(provider => provider.GetService<MetsiDbContext>());

            services.AddTransient(typeof(CategoryContext<>));
            services.AddTransient<ProblemsContext>();
            services.AddTransient<FaqContext>();

            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        /// <summary>
        /// This method gets called by the runtime. Configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The injected application builder</param>
        /// <param name="env">The injected host environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
