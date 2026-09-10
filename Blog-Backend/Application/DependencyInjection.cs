using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Application.Interfaces.HashServiceInterface;
using Application.Interfaces.UserServicesInterface;
using Application.Services.HashService;
using Application.Services.UserService;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class AddApplication
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHashService, HashService>();
            return services;
        }
    }
}
