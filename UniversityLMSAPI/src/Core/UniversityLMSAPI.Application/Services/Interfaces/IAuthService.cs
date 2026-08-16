using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLMSAPI.Application.DTOs.Auth;
using UniversityLMSAPI.Application.DTOs.Requests.Auth;
using UniversityLMSAPI.Application.DTOs.Responses;

namespace UniversityLMSAPI.Application.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<ApiResponse<LoginDTO>> LoginAsync(LoginRequestDTO request);
        public Task<ApiResponse<RegisterDTO>> RegisterAsync(RegisterDTO request);
    }
}
