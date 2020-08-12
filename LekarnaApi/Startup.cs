
namespace LekarnaApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using LekarnaApi.Data;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using LekarnaApi.Models;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using LekarnaApi.Infrastructure;
    using LekarnaApi.Data.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;


        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LekarnaDbContext>(options => options
               .UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<User, IdentityRole>(options => 
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<LekarnaDbContext>();

            var applicationSettingsConfiguration = this.Configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettingsConfiguration);

            var appSettings = applicationSettingsConfiguration.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            

            app.UseRouting();

            app.UseCors(options => options
            .WithExposedHeaders("Authorization")
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.ApplyMigrations();
        }
    }
}
