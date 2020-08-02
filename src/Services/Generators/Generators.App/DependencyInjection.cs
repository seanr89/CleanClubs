

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Generators.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddGeneratorApplication(this IServiceCollection services)
        {
            services.AddTransient<TeamGenerator>();
            return services;
        }
    }
}