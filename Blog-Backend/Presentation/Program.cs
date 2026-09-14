using Application;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.OpenApi;
using Blog_Backend.Extensions;
namespace Blog_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddConfigurationSwagger();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplicationLayer();
            builder.Services.AddFluentValidationAutoValidation();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
