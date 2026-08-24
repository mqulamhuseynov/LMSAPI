using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using UniversityLMSAPI.Application.DTOs.Auth;
using UniversityLMSAPI.Application.DTOs.Requests.Auth;
using UniversityLMSAPI.Application.Services.Interfaces;

namespace UniversityLMSAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO request) 
        {
        var result = await authService.RegisterUserAsync(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request) 
        {
        var res = await authService.LoginAsync(request); 
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRolePls([FromBody] CreateRoleDTO request) 
        {
           await authService.CreateRole(request);
            return Ok();
        }
    }
}
