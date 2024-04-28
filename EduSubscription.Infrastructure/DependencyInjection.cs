<<<<<<< HEAD
﻿using EduSubscription.Application.Providers;
=======
﻿using EduSubscription.Infrastructure.Jobs;
>>>>>>> fdd449e6ab4e088ca0012b59115889337f277c64
using EduSubscription.Infrastructure.Persistence;
using EduSubscription.Infrastructure.Persistence.Configurations;
using EduSubscription.Infrastructure.Persistence.Interceptors;
using EduSubscription.Infrastructure.Persistence.Repositories;
using EduSubscription.Infrastructure.Providers;
using EduSubscription.Infrastructure.Providers.Clients;
using EduSubscription.Infrastructure.Providers.Contracts;
using EduSubscription.Infrastructure.Providers.Options;
using EduSubscription.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EduSubscription.Infrastructure;

public static class DependencyInjection
{

<<<<<<< HEAD
    public static IServiceCollection AddAsaas(this IServiceCollection services)
    {
        services
            .ConfigureOptions<AsaasPaymentProviderOptionsSetup>()
            .AddScoped<IPaymentProvider, AsaasPaymentProvider>()
            .AddHttpClient<IPaymentClient, AsaasPaymentClient>((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<AsaasPaymentProviderOptions>>().Value;
                client.BaseAddress = new Uri(AsaasResource.AsaasSandboxBaseEndpoint);
                client.DefaultRequestHeaders.Add("ApiKey", options.ApiKey);
            });
=======
    public static IServiceCollection AddBackgroundJobs(this IServiceCollection services)
    {
        services.AddHostedService<MediatorPublishOutboxMessagesJob>();
>>>>>>> fdd449e6ab4e088ca0012b59115889337f277c64
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