

namespace UniversityLMSAPI.Domain.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid FacultyId { get; set; }

        public Faculty Faculty { get; set; } = null!;
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<GroupSubject> GroupSubjects { get; set; } = new List<GroupSubject>();
    }

}
