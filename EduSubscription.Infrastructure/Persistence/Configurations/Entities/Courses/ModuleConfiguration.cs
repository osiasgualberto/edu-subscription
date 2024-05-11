using EduSubscription.Core.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSubscription.Infrastructure.Persistence.Configurations.Entities.Courses;

public class ModuleConfiguration : BaseConfiguration<Module>
{
    public override void Configure(EntityTypeBuilder<Module> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Modules");
        builder.Property(o => o.Description).IsRequired();
        builder.Property(o => o.Name).IsRequired();
    }
}