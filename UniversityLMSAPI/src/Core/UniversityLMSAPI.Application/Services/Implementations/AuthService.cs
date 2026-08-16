using Microsoft.AspNetCore.Identity;
using UniversityLMSAPI.Application.DTOs.Auth;
using UniversityLMSAPI.Application.DTOs.Requests.Auth;
using UniversityLMSAPI.Application.DTOs.Responses;
using UniversityLMSAPI.Application.Services.Interfaces;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Application.Services.Implementations
{
    public class AuthService(UserManager<AppUser> userManager) : IAuthService
    {
        
        public async Task<ApiResponse<LoginDTO>> LoginAsync(LoginRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<RegisterDTO>> RegisterAsync(RegisterDTO request)
        {
            var existingUser = await userManager.FindByEmailAsync(request.Email);
            if (existingUser is not null) 
            {
            return ApiResponse<RegisterDTO>.FailResponse("User with this email already exists.", 400);
            }

            var newUser = new AppUser
            {
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PersonalCode = request.PersonalCode,
                PhoneNumber = request.Phone,
                FinCode = request.FinCode,
                Address = request.Address,
                City = request.City,
                Country = request.Country,
                BirthDate = request.BirthDate,
                AcceptedDate = request.AcceptedDate
            };

            var result = await userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded) {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                return ApiResponse<RegisterDTO>.FailResponse($"User creation failed: {errors}", 400);
            }

            return ApiResponse<RegisterDTO>.SuccessResponse(request, "User registered successfully.", 201);
        }
    }
}
