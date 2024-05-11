using EduSubscription.Infrastructure.Persistence;
using EduSubscription.Primitives.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace EduSubscription.Infrastructure.Jobs;

public class MediatorPublishOutboxMessagesJob : BackgroundService
{
    private readonly IServiceProvider _provider;

    public MediatorPublishOutboxMessagesJob(IServiceProvider provider)
    {
        _provider = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _provider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

        var outboxMessages = context
            .OutboxMessages
            .Where(o => !o.Processed)
            .ToList();

        foreach (var outboxMessage in outboxMessages)
        {
            var domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(outboxMessage.Content,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                });
            if (domainEvent is null) continue;
            await publisher.Publish(domainEvent, stoppingToken);
            outboxMessage.Processed = true;
        }

        await context.SaveChangesAsync();
    }
}