using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Persistence.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Date)
                .HasColumnType("date");

            builder.Property(a => a.Status)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Timetable)
                .WithMany(t => t.Attendances)
                .HasForeignKey(a => a.TimetableId)
                .OnDelete(DeleteBehavior.Cascade);

            // her sagird ucun her ders cədvəlində yalnız bir qeydiyyat olmasını təmin etmək üçün unikal indeks əlavə edin
            builder.HasIndex(a => new { a.StudentId, a.TimetableId })
                .IsUnique();
        }
    }
}
