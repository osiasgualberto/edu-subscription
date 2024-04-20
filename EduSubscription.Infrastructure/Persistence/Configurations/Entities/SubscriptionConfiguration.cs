using EduSubscription.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSubscription.Infrastructure.Persistence.Configurations.Entities;

public class SubscriptionConfiguration : BaseConfiguration<Subscription>
{
    public override void Configure(EntityTypeBuilder<Subscription> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Subscriptions");
        builder
            .HasOne<Plan>(o => o.Plan)
            .WithMany()
            .HasForeignKey(o => o.IdPlan)
            .OnDelete(DeleteBehavior.Restrict);
    }
}