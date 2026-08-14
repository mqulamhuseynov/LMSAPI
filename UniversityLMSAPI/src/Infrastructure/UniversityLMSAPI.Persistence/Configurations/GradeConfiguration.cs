using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Persistence.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Score)
                .HasColumnType("numeric(5,2)");

            builder.Property(g => g.GradedAt)
                .HasColumnType("timestamptz");

            builder.HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Assignment)
                .WithMany(a => a.Grades)
                .HasForeignKey(g => g.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // her sagird ucun her assignmente 1 qiymet verile biler, duplicate olmamali
            builder.HasIndex(g => new { g.StudentId, g.AssignmentId })
                .IsUnique();
        }
    }
}
