
using System.Text.RegularExpressions;

namespace UniversityLMSAPI.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }

        public AppUser User { get; set; } = null!;
        public Group Group { get; set; } = null!;

        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
