

using Clubs.Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;
using MediatR;
using Clubs.Application.Business;
using FluentValidation;
using Microsoft.Azure.ServiceBus;
using Clubs.Messages;
using Microsoft.Extensions.Configuration;
using Clubs.Application.Services.Interfaces;
using Clubs.Application.Services;
using Clubs.Application.Profiles.DTO;
using Clubs.Application.Services.Factories;
using Microsoft.AspNetCore.Http;

namespace Clubs.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DBUpdateExceptionBehaviour<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient<ITeamGenerator, TeamGenerator>();
            services.AddTransient<GenerationService>();
            services.AddTransient<MatchManager>();

            services.AddSingleton<ITopicClient>(x => new TopicClient(configuration.GetValue<string>("ServiceBus:ConnectionString")
            , configuration.GetValue<string>("ServiceBus:TopicName")));
            services.AddSingleton<IMessagePublisher, InvitationPublisher>();

            services.AddTransient<IMatchCreator, SimpleMatchCreator>();
            services.AddTransient<IMatchCreator, InvitationMatchCreator>();
            services.AddTransient<MatchCreationFactory>();

            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}