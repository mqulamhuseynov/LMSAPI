

namespace UniversityLMSAPI.Domain.Entities
{
    public class GroupSubject
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid SemesterId { get; set; }

        public Group Group { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;
        public Subject Subject { get; set; } = null!;
        public Semester Semester { get; set; } = null!;

        public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public ICollection<CourseMaterial> CourseMaterials { get; set; } = new List<CourseMaterial>();
    }
}
