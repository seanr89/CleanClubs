using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;
using MediatR;
using System;

namespace Clubs.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        /// <summary>
        /// Handle the management for API Dependency Injection
        /// </summary>
        /// <param name="services">startup service collection</param>
        /// <returns>services returned with injected dependencies</returns>
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            Console.WriteLine("ConfigureDependencies");
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}