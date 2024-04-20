using EduSubscription.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSubscription.Infrastructure.Persistence.Configurations.Entities;

public class PlanConfiguration : BaseConfiguration<Plan>
{
    public override void Configure(EntityTypeBuilder<Plan> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Plans");
        builder.Property(o => o.Description).IsRequired().HasMaxLength(200);
        builder.Property(o => o.Description).IsRequired();
    }
}