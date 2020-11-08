using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Clubs.Infrastructure;
using System.Reflection;
using AutoMapper;
using MediatR;
using System;

namespace Clubs.API.Extensions
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

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClubsContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionSettings:Default"],
                sqlServerOptionsAction: sqlOptions =>
                {
                    
                    sqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(1).TotalSeconds);
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null);
                    sqlOptions.UseNetTopologySuite();
                });
            });
        }
    }
}