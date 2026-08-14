using Microsoft.AspNetCore.Identity;

namespace UniversityLMSAPI.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
