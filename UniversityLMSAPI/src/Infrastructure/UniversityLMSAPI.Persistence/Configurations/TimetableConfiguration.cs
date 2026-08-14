using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Persistence.Configurations
{
    public class TimetableConfiguration : IEntityTypeConfiguration<Timetable>
    {
        public void Configure(EntityTypeBuilder<Timetable> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.StartTime)
                .HasColumnType("time");

            builder.Property(t => t.EndTime)
                .HasColumnType("time");

            builder.HasOne(t => t.GroupSubject)
                .WithMany(gs => gs.Timetables)
                .HasForeignKey(t => t.GroupSubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Classroom)
                .WithMany(c => c.Timetables)
                .HasForeignKey(t => t.ClassroomId)
                .OnDelete(DeleteBehavior.Restrict);

            //eyni otag 2 ders ucun eyni vaxtda ola bilmez. Buna gore unique constraint elave edirik.
            builder.HasIndex(t => new { t.ClassroomId, t.DayOfWeek, t.StartTime })
                .IsUnique();
        }
    }

}
