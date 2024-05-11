using EduSubscription.Core.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSubscription.Infrastructure.Persistence.Configurations.Entities.Courses;

public class LessonConfiguration : BaseConfiguration<Lesson>
{
    public override void Configure(EntityTypeBuilder<Lesson> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Lessons");
        builder.HasOne(o => o.Module).WithMany().HasForeignKey(o => o.IdModule).IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(o => o.Description).IsRequired();
        builder.Property(o => o.Name).IsRequired();
    }
}