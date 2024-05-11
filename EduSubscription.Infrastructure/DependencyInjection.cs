using EduSubscription.Application.Providers;
using EduSubscription.Application.Providers.Payment;
using EduSubscription.Infrastructure.Jobs;
using EduSubscription.Infrastructure.Persistence;
using EduSubscription.Infrastructure.Persistence.Configurations;
using EduSubscription.Infrastructure.Persistence.Interceptors;
using EduSubscription.Infrastructure.Persistence.Repositories;
using EduSubscription.Infrastructure.Providers;
using EduSubscription.Infrastructure.Providers.Asaas;
using EduSubscription.Infrastructure.Providers.Asaas.Clients;
using EduSubscription.Infrastructure.Providers.Asaas.Contracts;
using EduSubscription.Infrastructure.Providers.Asaas.Options;
using EduSubscription.Infrastructure.Providers.Asaas.Serialization;
using EduSubscription.Infrastructure.Providers.Asaas.Serialization.Abstractions;
using EduSubscription.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EduSubscription.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddAsaas(this IServiceCollection services)
    {
        services
            .ConfigureOptions<PaymentProviderOptionsSetup>()
            .AddScoped<IPaymentProvider, PaymentProvider>()
            .AddScoped<IPaymentSerializer, PaymentSerializer>()
            .AddHttpClient<IPaymentHttpClient, PaymentHttpHttpClient>((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<PaymentProviderOptions>>().Value;
                client.BaseAddress = new Uri(Resources.SandboxBaseEndpoint);
                client.DefaultRequestHeaders.Add("access_token", options.ApiKey);
            });
        return services;
    }

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
            .AddScoped<IMemberRepository, MemberRepository>()
            .AddScoped<IPaymentRepository, PaymentRepository>()
            .AddScoped<ICourseRepository, CourseRepository>();
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