using System.Runtime.CompilerServices;
using System.Text;
using Application.Interfaces.AuthInterfaces;
using Domain.Interfaces;
using Infrastructure.Auth;
using Infrastructure.Persistence.DbContexts;
using Infrastructure.Repositores.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
namespace Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
            services.AddScoped<IJwtProvider, JwtProvider>();
            var connectionString = configuration.GetConnectionString("DefaultConnection")?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!))

                };

            });
           
            return services;
        }
    }
}
