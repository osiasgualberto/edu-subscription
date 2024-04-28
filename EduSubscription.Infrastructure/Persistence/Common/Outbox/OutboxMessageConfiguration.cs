using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSubscription.Infrastructure.Persistence.Common.Outbox;

public class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable("tbl_OutboxMessages");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.CreatedAt).HasDefaultValue(DateTime.Now);
    }
}