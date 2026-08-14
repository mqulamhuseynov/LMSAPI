

namespace UniversityLMSAPI.Domain.Entities
{
    public class Semester
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!; 
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public ICollection<GroupSubject> GroupSubjects { get; set; } = new List<GroupSubject>();
    }
}
