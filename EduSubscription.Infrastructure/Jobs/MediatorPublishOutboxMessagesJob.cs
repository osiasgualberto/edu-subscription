using System.Text.Json;
using EduSubscription.Infrastructure.Persistence;
using EduSubscription.Primitives.Contracts;
using MediatR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace EduSubscription.Infrastructure.Jobs;

public class MediatorPublishOutboxMessagesJob : BackgroundService
{
    private readonly AppDbContext _appDbContext;
    private readonly IPublisher _publisher;

    public MediatorPublishOutboxMessagesJob(AppDbContext appDbContext, IPublisher publisher)
    {
        _appDbContext = appDbContext;
        _publisher = publisher;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var outboxMessages = _appDbContext
            .OutboxMessages
            .Where(o => !o.Processed);
        
        foreach (var outboxMessage in outboxMessages)
        {
            var domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(outboxMessage.Content);
            if (domainEvent is null) continue;
            await _publisher.Publish(domainEvent, stoppingToken);
        }
    }
}