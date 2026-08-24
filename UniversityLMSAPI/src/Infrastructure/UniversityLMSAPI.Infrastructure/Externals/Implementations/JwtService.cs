using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UniversityLMSAPI.Application.Services.Interfaces.Externals;
using UniversityLMSAPI.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace UniversityLMSAPI.Infrastructure.Externals.Implementations
{
    public class JwtService(UserManager<AppUser> userManager, IOptions<JwtSettings> jwtOptions) : IJwtService
    {
        private readonly JwtSettings _jwtSettings = jwtOptions.Value;

        public async Task<string> GenerateAccessTokenAsync(AppUser user)
        {
            var roles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
