using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityLMSAPI.Application.DTOs.Auth;
using UniversityLMSAPI.Application.Services.Interfaces;

namespace UniversityLMSAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO request) 
        {
        var result = await authService.RegisterAsync(request);
            return Ok(result);
        }
    }
}
