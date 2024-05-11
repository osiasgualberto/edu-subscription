using EduSubscription.Core.Courses;
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
    /// Base constructor.
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Subscription> Subscriptions { get; set; } = null!;
    public DbSet<Plan> Plans { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<OutboxMessage> OutboxMessages { get; set; } = null!;
    public DbSet<Member> Members { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}