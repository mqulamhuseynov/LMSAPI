
namespace UniversityLMSAPI.Application.DTOs.Responses
{
    public class AuthResponse
    {
        public string Token { get; set; } = null!;
        public string ExpirationMin { get; set; } = null!;

    }
}
