using EduSubscription.Core.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSubscription.Infrastructure.Persistence.Configurations.Entities.Courses;

public class CourseConfiguration : BaseConfiguration<Course>
{
    public override void Configure(EntityTypeBuilder<Course> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Courses");
        builder.Property(o => o.Name).IsRequired();
        builder.Property(o => o.Description).IsRequired();
        builder.Property(o => o.Cover).IsRequired(false);
    }
}