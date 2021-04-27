using Blogging.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Feedback.Core.Extensions;
using Filing.Core.Factories;
using Iqt.Base.Interfaces;
using IQTechSolutions.DataStores;
using Microsoft.EntityFrameworkCore;

namespace IQTechSolutions.Web.Api
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
            services.AddAuthentication().AddJwtBearer("Bearer", config =>
            {
                config.Authority = "https://localhost:4001/";
                config.Audience = "MainApi";
            });

            services.AddDbContext<IQTechSolutionsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContext, IQTechSolutionsDbContext>();

            services.AddTransient<IFileFactory, FileFactory>();
            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();

            services.AddSupportTicketSystem().AddBlogging();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IQTechSolutions.Web.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IQTechSolutions.Web.Api v1"));
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
