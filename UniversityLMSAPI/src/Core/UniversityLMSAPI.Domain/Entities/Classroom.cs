
namespace UniversityLMSAPI.Domain.Entities
{
    public class Classroom
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; } = null!;
        public int Capacity { get; set; }

        public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
    }
}
