

namespace UniversityLMSAPI.Domain.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }

        public AppUser User { get; set; } = null!;
        public Department Department { get; set; } = null!;

        public ICollection<GroupSubject> GroupSubjects { get; set; } = new List<GroupSubject>();
    }
}
