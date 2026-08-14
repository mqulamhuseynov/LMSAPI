using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Persistence.Configurations
{
    public class GroupSubjectConfiguration : IEntityTypeConfiguration<GroupSubject>
    {
        public void Configure(EntityTypeBuilder<GroupSubject> builder)
        {
            builder.HasKey(gs => gs.Id);

            builder.HasOne(gs => gs.Group)
                .WithMany(g => g.GroupSubjects)
                .HasForeignKey(gs => gs.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(gs => gs.Teacher)
                .WithMany(t => t.GroupSubjects)
                .HasForeignKey(gs => gs.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(gs => gs.Subject)
                .WithMany(s => s.GroupSubjects)
                .HasForeignKey(gs => gs.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(gs => gs.Semester)
                .WithMany(s => s.GroupSubjects)
                .HasForeignKey(gs => gs.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);

            //eyni mellim eyni dersi eyni qrupa 2 defe kecmemelidi
            builder.HasIndex(gs => new { gs.GroupId, gs.SubjectId, gs.SemesterId })
                .IsUnique();
        }
    }
}
