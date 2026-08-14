

namespace UniversityLMSAPI.Domain.Entities
{
    public class Faculty
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Department> Departments { get; set; } = new List<Department>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
