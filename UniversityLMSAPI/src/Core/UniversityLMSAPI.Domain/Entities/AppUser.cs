using Microsoft.AspNetCore.Identity;

namespace UniversityLMSAPI.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PersonalCode { get; set; } = string.Empty;
        public string FinCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime AcceptedDate { get; set; }
        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
