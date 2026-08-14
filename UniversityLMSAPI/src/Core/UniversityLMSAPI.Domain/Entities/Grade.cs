

namespace UniversityLMSAPI.Domain.Entities
{
    public class Grade
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid AssignmentId { get; set; }
        public decimal Score { get; set; }
        public DateTime GradedAt { get; set; }

        public Student Student { get; set; } = null!;
        public Assignment Assignment { get; set; } = null!;
    }
}
