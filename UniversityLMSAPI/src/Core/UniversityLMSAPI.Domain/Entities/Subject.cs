

namespace UniversityLMSAPI.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<GroupSubject> GroupSubjects { get; set; } = new List<GroupSubject>();
    }
}
