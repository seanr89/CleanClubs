using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System;

namespace Emails.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy($"{configuration["Cors:PolicyName"]}",
                    builder => builder.WithOrigins($"{configuration["Cors:Origin"]}")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            //builder => builder.AllowAnyOrigin()
        }
    }
}