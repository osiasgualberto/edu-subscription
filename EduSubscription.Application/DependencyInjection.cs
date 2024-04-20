using Microsoft.Extensions.DependencyInjection;

namespace EduSubscription.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return services;
    }
}