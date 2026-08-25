using Microsoft.AspNetCore.Identity;
using UniversityLMSAPI.Application.DTOs.Auth;
using UniversityLMSAPI.Application.DTOs.Requests.Auth;
using UniversityLMSAPI.Application.DTOs.Responses;
using UniversityLMSAPI.Application.Services.Interfaces;
using UniversityLMSAPI.Application.Services.Interfaces.Externals;
using UniversityLMSAPI.Domain.Entities;
using UniversityLMSAPI.Domain.Enums;
using UniversityLMSAPI.Persistence.Repositories.Interface;

namespace UniversityLMSAPI.Application.Services.Implementations
{
    public class AuthService(UserManager<AppUser> userManager,
        IJwtService jwtService,
        RoleManager<IdentityRole<Guid>> roleManager,
        IStudentRepository studentRepository,
        IUnitOfWork uow) : IAuthService
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
                ExpirationMin = "15m"
            };


            return ApiResponse<AuthResponse>.SuccessResponse(authResponse, "Succesfully logged in", 200);

        }

        public async Task<ApiResponse<AuthResponse>> RegisterStudentAsync(RegisterStudentDTO request)
        {
            var existingUser = await userManager.FindByEmailAsync(request.Email);
            if (existingUser is not null) 
            {
                return ApiResponse<AuthResponse>.FailResponse("This user already exists", 409);
            }
            try
            {
                var newUser = new AppUser
                {
                    UserName = request.PersonalCode,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PersonalCode = request.PersonalCode,
                    FinCode = request.FinCode,
                    AcceptedDate = DateTime.UtcNow,
                    City = request.City,
                    Country = request.Country,
                    BirthDate = request.BirthDate,
                    Address = request.Address,
                    PhoneNumber = request.Phone,
                };
                var result = await userManager.CreateAsync(newUser, request.Password);


                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return ApiResponse<AuthResponse>.FailResponse(errors, 400);
                }

                var roleResult = await userManager.AddToRoleAsync(newUser, nameof(AppRole.Student));
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Failed to assign role to user.");
                }

                Student student = new Student
                {
                    UserId = newUser.Id,
                    GroupId = request.GroupId,
                };

                await studentRepository.AddAsync(student);
                await uow.SaveChangesAsync();

                var accessToken = await jwtService.GenerateAccessTokenAsync(newUser);

                AuthResponse response = new AuthResponse
                {
                    Token = accessToken,
                    ExpirationMin = "15m" 
                };

                return ApiResponse<AuthResponse>.SuccessResponse(response, "Successfully registered halaldi qardasm");
            }
            catch 
            {
                return ApiResponse<AuthResponse>.FailResponse("Something went wrong during registration", 500);
            }
        }
            
        

        public async Task<ApiResponse<AuthResponse>> RegisterTeacherAsync(RegisterTeacherDTO request)
        {
            var existingUser = await userManager.FindByEmailAsync(request.Email);
            if (existingUser is not null) 
            {
                return ApiResponse<AuthResponse>.FailResponse("This user already exists", 409);
            }

            AppUser newUser = new AppUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PersonalCode = request.PersonalCode,
                FinCode = request.FinCode,
                AcceptedDate = DateTime.UtcNow,
                City = request.City,
                Country = request.Country,
                BirthDate = request.BirthDate,
                Address = request.Address,
                PhoneNumber = request.Phone
            };

            var result = await userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded) 
            {
                return ApiResponse<AuthResponse>.FailResponse("Something went wrong", 500);
            }

            var accessToken = await jwtService.GenerateAccessTokenAsync(newUser);

            var authResponse = new AuthResponse
            {
                Token = accessToken,
                ExpirationMin = "15m"
            };

            return ApiResponse<AuthResponse>.SuccessResponse(authResponse, "Successfully registered: Teacher");

        }
    }
}
