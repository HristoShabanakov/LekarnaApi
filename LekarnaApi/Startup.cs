
namespace LekarnaApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using LekarnaApi.Data;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using LekarnaApi.Infrastructure.Extensions;
    using LekarnaApi.Infrastructure.Filters;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;


        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)

            => services
             .AddDatabase(this.Configuration)
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration))
                .AddApplicationServices()
                .AddApiControllers();


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app
               .UseRouting()
               .UseCors(options => options
                 .WithExposedHeaders("Authorization")
                 .AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod())
               .UseAuthentication()
               .UseAuthorization()

               .UseEndpoints(endpoints =>
               {
                endpoints.MapControllers();
               })

            .ApplyMigrations();
        }
    }
}
