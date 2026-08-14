

namespace UniversityLMSAPI.Domain.Entities
{
    public class CourseMaterial
    {
        public Guid Id { get; set; }
        public Guid GroupSubjectId { get; set; }
        public string Title { get; set; } = null!;
        public string FileUrl { get; set; } = null!;
        public DateTime UploadedAt { get; set; }

        public GroupSubject GroupSubject { get; set; } = null!;
    }
}
