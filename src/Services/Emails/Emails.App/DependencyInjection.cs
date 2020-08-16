

using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Emails.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEmailApplication(this IServiceCollection services)
        {
            services.AddTransient<EmailHandler>();
            services.AddSingleton<ISubscriptionClient>(x =>
                new SubscriptionClient("", "", ""));
            return services;
        }
    }
}