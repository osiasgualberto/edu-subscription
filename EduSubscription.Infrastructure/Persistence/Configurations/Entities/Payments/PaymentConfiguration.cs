using EduSubscription.Core.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSubscription.Infrastructure.Persistence.Configurations.Entities.Payments;

public class PaymentConfiguration : BaseConfiguration<Payment>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Payments");
        builder.HasOne(o => o.Subscription).WithMany().HasForeignKey(o => o.IdSubscription).IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(o => o.PaymentStatus).IsRequired();
        builder.Property(o => o.Value).IsRequired();
        builder.Property(o => o.DueDate).IsRequired();
        builder.Property(o => o.LastProcessedDate).IsRequired(false);
        builder.Property(o => o.Link).IsRequired(false);
        builder.Property(o => o.Value).HasPrecision(15, 4);
    }
}