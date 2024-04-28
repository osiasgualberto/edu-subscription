using System.Text.Json;
using EduSubscription.Infrastructure.Persistence.Common.Outbox;
using EduSubscription.Primitives;
using EduSubscription.Primitives.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace EduSubscription.Infrastructure.Persistence.Interceptors;

public class ConvertDomainEventToOutboxMessageInterceptor : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        DbContext? context = eventData.Context;
        if (context is null) return await base.SavingChangesAsync(eventData, result, cancellationToken);
        await Execute(context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public async Task Execute(DbContext context)
    {
        var outboxMessages = context.ChangeTracker
            .Entries<Entity>()
            .Select(o => o.Entity)
            .SelectMany(o => o.Events)
            .Select(o => new OutboxMessage()
            {
                Type = o.GetType().Name,
                Content = JsonConvert.SerializeObject(o, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                })
            })
            .ToList();
        await context.Set<OutboxMessage>().AddRangeAsync(outboxMessages);
    }
}