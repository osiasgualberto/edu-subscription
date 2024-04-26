using EduSubscription.Infrastructure.Jobs;
using EduSubscription.Infrastructure.Persistence;
using EduSubscription.Infrastructure.Persistence.Configurations;
using EduSubscription.Infrastructure.Persistence.Interceptors;
using EduSubscription.Infrastructure.Persistence.Repositories;
using EduSubscription.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EduSubscription.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddBackgroundJobs(this IServiceCollection services)
    {
        services.AddHostedService<MediatorPublishOutboxMessagesJob>();
        return services;
    }
    
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services
            .ConfigureOptions<AppDbContextOptionsSetup>()
            .AddSingleton<ConvertDomainEventToOutboxMessageInterceptor>()
            .AddDbContext<AppDbContext>(((provider, builder) =>
            {
                var appDbContextOptions =
                    provider.GetService(typeof(IOptions<AppDbContextOptions>)) as IOptions<AppDbContextOptions>;
                if (appDbContextOptions is null) return;
                builder.UseSqlServer(appDbContextOptions.Value.ConnectionString)
                    .AddInterceptors(provider.GetRequiredService<ConvertDomainEventToOutboxMessageInterceptor>());
            }))
            .AddScoped<IUnitOfWork, AppUnitOfWork>()
            .AddScoped<ISubscriptionRepository, SubscriptionRepository>()
            .AddScoped<IPlanRepository, PlanRepository>()
            .AddScoped<IPaymentRepository, PaymentRepository>();
        return services;
    }

    public static IServiceProvider RunMigrations(this IServiceProvider provider)
    {
        var scope = provider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
        return provider;
    }
}