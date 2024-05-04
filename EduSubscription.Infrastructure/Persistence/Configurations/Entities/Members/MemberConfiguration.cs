using EduSubscription.Core.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSubscription.Infrastructure.Persistence.Configurations.Entities.Members;

public class MemberConfiguration : BaseConfiguration<Member> 
{
    public override void Configure(EntityTypeBuilder<Member> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Member");
        builder.Property(o => o.FirstName).IsRequired().HasMaxLength(20);
        builder.Property(o => o.LastName).IsRequired().HasMaxLength(20);
        builder.Property(o => o.DocumentNumber).IsRequired().HasMaxLength(20);
        builder.Property(o => o.Email).IsRequired().HasMaxLength(20);
    }
}