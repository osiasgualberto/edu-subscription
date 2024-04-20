using EduSubscription.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSubscription.Infrastructure.Persistence.Configurations.Entities;

public class PaymentConfiguration : BaseConfiguration<Payment>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Payments");
        builder.Property(o => o.Status).IsRequired();
        builder.Property(o => o.Value).IsRequired();
        builder.Property(o => o.DueDate).IsRequired();
        builder.Property(o => o.ProcessedDate).IsRequired(false);
        builder.Property(o => o.Link).IsRequired(false);
        builder.Property(o => o.Value).HasPrecision(15, 4);
    }
}