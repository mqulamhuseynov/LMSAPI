
using UniversityLMSAPI.Domain.Enums;

namespace UniversityLMSAPI.Domain.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid TimetableId { get; set; }
        public DateOnly Date { get; set; }
        public AttendanceStatus Status { get; set; }

        public Student Student { get; set; } = null!;
        public Timetable Timetable { get; set; } = null!;
    }
}
