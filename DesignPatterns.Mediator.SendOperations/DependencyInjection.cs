using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DesignPatterns.Mediator.SendOperations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediator(this IServiceCollection services,
            Assembly handlersAssembly)
        {
            services.AddSingleton<IMediator>(provider => new Mediator(handlersAssembly));
            return services;
        }
    }
}
