using EduSubscription.Core.Members;
using EduSubscription.Core.Members.Errors;
using EduSubscription.Core.Plans;
using EduSubscription.Core.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSubscription.Infrastructure.Persistence.Configurations.Entities.Subscriptions;

public class SubscriptionConfiguration : BaseConfiguration<Subscription>
{
    public override void Configure(EntityTypeBuilder<Subscription> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Subscriptions");
        builder.Property(o => o.Value).HasPrecision(15, 4);
        builder.HasOne<Plan>(o => o.Plan).WithMany().HasForeignKey(o => o.IdPlan).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Member>(o => o.Member).WithMany().HasForeignKey(o => o.IdMember)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
