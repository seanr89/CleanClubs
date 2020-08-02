

using Clubs.Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;
using MediatR;
using Clubs.Application.Business;
using FluentValidation;

namespace Clubs.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient<ITeamGenerator, TeamGenerator>();
            services.AddTransient<SimpleEmailHandler>();

            services.AddTransient<MatchManager>();

            return services;
        }
    }
}