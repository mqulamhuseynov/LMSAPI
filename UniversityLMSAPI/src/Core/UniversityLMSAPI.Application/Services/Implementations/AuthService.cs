using Microsoft.AspNetCore.Identity;
using UniversityLMSAPI.Application.DTOs.Auth;
using UniversityLMSAPI.Application.DTOs.Requests.Auth;
using UniversityLMSAPI.Application.DTOs.Responses;
using UniversityLMSAPI.Application.Services.Interfaces;
using UniversityLMSAPI.Application.Services.Interfaces.Externals;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Application.Services.Implementations
{
    public class AuthService(UserManager<AppUser> userManager,
        IJwtService jwtService,
        RoleManager<IdentityRole<Guid>> roleManager) : IAuthService
    {
        
        public async Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequestDTO request)
        {
            var user = await userManager.FindByNameAsync(request.PersonalCode);

            if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
                return ApiResponse<AuthResponse>.FailResponse("Email or Password is wrong", 400);

            var accessToken = await jwtService.GenerateAccessTokenAsync(user);

            var authResponse = new AuthResponse
            {
                Token = accessToken,
                ExpirationMin = "60m"
            };


            return ApiResponse<AuthResponse>.SuccessResponse(authResponse, "Succesfully logged in", 200);

        }

        public async Task CreateRole(CreateRoleDTO dto) 
        {
            IdentityRole<Guid> role = new() { Name = dto.RoleName };
            await roleManager.CreateAsync(role);
        }

        public async Task<ApiResponse<AuthResponse>> RegisterUserAsync(RegisterStudentDTO request)
        {
            var existingUser = await userManager.FindByEmailAsync(request.Email);
            if (existingUser is not null) 
            {
                return ApiResponse<AuthResponse>.FailResponse("This user already exists. Son(agliyan smaylik emojisi",401);
            }

            var newUser = new AppUser
            {
                UserName = request.PersonalCode,
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
               
                return ApiResponse<AuthResponse>.FailResponse("During register something happened son", 400);
            }

            var accessToken = await jwtService.GenerateAccessTokenAsync(newUser);

            AuthResponse authResponse = new AuthResponse
            {
                Token = accessToken,
                ExpirationMin = "60m"
            };

            return ApiResponse<AuthResponse>.SuccessResponse(authResponse);
        }
    }
}
