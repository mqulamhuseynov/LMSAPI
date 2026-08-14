using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Persistence.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Type)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(a => a.Deadline)
                .HasColumnType("timestamptz");

            builder.HasOne(a => a.GroupSubject)
                .WithMany(gs => gs.Assignments)
                .HasForeignKey(a => a.GroupSubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
