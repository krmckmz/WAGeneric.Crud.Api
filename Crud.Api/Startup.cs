using Crud.Core;
using Crud.Core.Services.Abstract;
using Crud.Data;
using Crud.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Crud.Api
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
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "GenericCrud", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPluginService, PluginService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddDbContext<CrudDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection"), x => x.MigrationsAssembly("Crud.Data"))); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("swagger/v1/swagger.json", "GenericCrud v1");
            });
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
