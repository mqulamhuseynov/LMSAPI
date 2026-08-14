using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Persistence.Configurations
{
    public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.RoomNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(c => c.RoomNumber)
                .IsUnique();
        }
    }
}
