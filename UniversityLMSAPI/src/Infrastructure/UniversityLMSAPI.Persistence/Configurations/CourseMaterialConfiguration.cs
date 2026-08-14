using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Persistence.Configurations
{
    public class CourseMaterialConfiguration : IEntityTypeConfiguration<CourseMaterial>
    {
        public void Configure(EntityTypeBuilder<CourseMaterial> builder)
        {
            builder.HasKey(cm => cm.Id);

            builder.Property(cm => cm.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(cm => cm.FileUrl)
                .IsRequired();

            builder.Property(cm => cm.UploadedAt)
                .HasColumnType("timestamptz");

            builder.HasOne(cm => cm.GroupSubject)
                .WithMany(gs => gs.CourseMaterials)
                .HasForeignKey(cm => cm.GroupSubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
