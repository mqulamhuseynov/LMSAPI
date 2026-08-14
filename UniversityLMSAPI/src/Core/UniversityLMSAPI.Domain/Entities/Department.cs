

namespace UniversityLMSAPI.Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid FacultyId { get; set; }

        public Faculty Faculty { get; set; } = null!;
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
