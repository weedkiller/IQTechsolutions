using Blogging.Core.Extensions;
using Customers.Core.Extensions;
using Education.Core.Extensions;
using Filing.Core.Factories;
using Grouping.Core.Extensions;
using Iqt.Base.Interfaces;
using Metsi.Web.DataStore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Projects.Core.Extensions;
using Services.Core.Extensions;
using Troubleshooting.Core.Extensions;

namespace Metsi.Web.Api
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

            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();
            services.AddTransient<IFileFactory, FileFactory>();

            services.AddGrouping().AddTroubleshooting().AddFaqs().AddCustomers().AddServiceModule().AddBlogging().AddCourses().AddProjects();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Metsi Web Service", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Metsi.Web.Api v1");
                    //  c.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Metsi.Web.Api v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
