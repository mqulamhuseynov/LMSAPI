
using UniversityLMSAPI.Domain.Enums;


namespace UniversityLMSAPI.Domain.Entities
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public Guid GroupSubjectId { get; set; }
        public string Title { get; set; } = null!;
        public AssignmentType Type { get; set; }
        public DateTime Deadline { get; set; }
        public int MaxScore { get; set; }

        public GroupSubject GroupSubject { get; set; } = null!;
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
