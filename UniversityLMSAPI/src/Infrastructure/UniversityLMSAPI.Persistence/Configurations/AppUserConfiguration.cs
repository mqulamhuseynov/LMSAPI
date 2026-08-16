using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PersonalCode).IsRequired().HasMaxLength(50);
            builder.Property(u => u.FinCode).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Address).IsRequired().HasMaxLength(200);
            builder.Property(u => u.City).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Country).IsRequired().HasMaxLength(100);
            builder.Property(u => u.BirthDate).IsRequired();
            builder.Property(u => u.AcceptedDate).IsRequired();
        }
    }
}   