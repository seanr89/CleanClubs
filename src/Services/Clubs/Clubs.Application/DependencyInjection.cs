

using Clubs.Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;
using MediatR;
using Clubs.Application.Business;
using FluentValidation;
using Microsoft.Azure.ServiceBus;
using Clubs.Messages;

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

            services.AddSingleton<IQueueClient>(x => new QueueClient("Endpoint=sb://clubservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=I5e1gccbgKAOsIn6m1L30NYpEcZx0KC++eWsll0z4+o="
            , "invitationqueue"));
            services.AddSingleton<IMessagePublisher, InvitationPublisher>();
            
            return services;
        }
    }
}