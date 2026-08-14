
namespace UniversityLMSAPI.Domain.Entities
{
    public class Timetable
    {
        public Guid Id { get; set; }
        public Guid GroupSubjectId { get; set; }
        public Guid ClassroomId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public GroupSubject GroupSubject { get; set; } = null!;
        public Classroom Classroom { get; set; } = null!;

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
