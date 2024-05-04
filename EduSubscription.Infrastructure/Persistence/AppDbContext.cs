using EduSubscription.Core.Members;
using EduSubscription.Core.Payments;
using EduSubscription.Core.Plans;
using EduSubscription.Core.Subscriptions;
using EduSubscription.Infrastructure.Persistence.Common.Outbox;
using EduSubscription.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduSubscription.Infrastructure.Persistence;

/// <summary>
/// Represents a context to access the database.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Required by EFCore.
    /// </summary>
    private AppDbContext(IPublisher publisher)
    {
        _publisher = publisher;
    }

    /// <summary>
    /// Base constructor.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="publisher"></param>
    public AppDbContext(DbContextOptions options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    /// <summary>
    /// Mediator publisher property.
    /// </summary>
    private readonly IPublisher _publisher;

    public DbSet<Subscription> Subscriptions { get; set; } = null!;
    public DbSet<Plan> Plans { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<OutboxMessage> OutboxMessages { get; set; } = null!;
    public DbSet<Member> Members { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    /// <summary>
    /// Overrided save changes that publishes all messages before saving changes.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!)
    {
        var events = ChangeTracker
            .Entries<Entity>()
            .SelectMany(o => o.Entity.Events);
        foreach(var ev in events)
        {
            await _publisher.Publish(ev);
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}