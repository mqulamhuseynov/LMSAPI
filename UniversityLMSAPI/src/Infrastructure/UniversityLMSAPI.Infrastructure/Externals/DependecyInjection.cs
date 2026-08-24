using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using UniversityLMSAPI.Application.Services.Interfaces.Externals;
using UniversityLMSAPI.Infrastructure.Externals.Implementations;

namespace UniversityLMSAPI.Infrastructure.Externals
{
        public static class DependencyInjection
        {
            public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
            {
                var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>()
                    ?? throw new InvalidOperationException("Jwt section is missing in configuration.");

                services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
                services.AddScoped<IJwtService, JwtService>();
            
           

                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                        ClockSkew = TimeSpan.Zero,
                        RoleClaimType = ClaimTypes.Role
                    };
                });



                return services;
            }
        }
    }

