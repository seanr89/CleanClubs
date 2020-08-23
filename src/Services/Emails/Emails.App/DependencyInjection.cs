

using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Emails.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEmailApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<EmailHandler>();
            services.AddSingleton<ISubscriptionClient>(x =>
                new SubscriptionClient(configuration.GetValue<string>("ServiceBus:ConnectionString")
                , configuration.GetValue<string>("ServiceBus:TopicName")
                , configuration.GetValue<string>("ServiceBus:Subscription")));

            services.AddHostedService<InvitationReceieverService>();
            return services;
        }
    }
}