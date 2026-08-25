

namespace UniversityLMSAPI.Application.DTOs.Auth
{
    public class RegisterTeacherDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PersonalCode { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FinCode { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public Guid DepartmentId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AcceptedDate { get; set; }
    }
}
