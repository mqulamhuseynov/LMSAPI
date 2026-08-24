
using UniversityLMSAPI.Application.DTOs.Auth;
using UniversityLMSAPI.Application.DTOs.Requests.Auth;
using UniversityLMSAPI.Application.DTOs.Responses;

namespace UniversityLMSAPI.Application.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequestDTO request);
        public Task<ApiResponse<AuthResponse>> RegisterUserAsync(RegisterDTO request);
        public Task CreateRole(CreateRoleDTO dto);
    }
}
