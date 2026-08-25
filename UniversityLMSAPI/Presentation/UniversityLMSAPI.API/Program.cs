using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UniversityLMSAPI.Application.Services.Implementations;
using UniversityLMSAPI.Application.Services.Interfaces;
using UniversityLMSAPI.Domain.Entities;
using UniversityLMSAPI.Domain.Enums;
using UniversityLMSAPI.Infrastructure.Externals;
using UniversityLMSAPI.Persistence.Data;

namespace UniversityLMSAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
            {
                //identity options configleri
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddRoles<IdentityRole<Guid>>(); ;


            //Dependecy injections
            builder.Services.AddJwtAuthentication(builder.Configuration);
            builder.Services.AddScoped<IAuthService, AuthService>();



            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LMS.API",
                    Version = "v1"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Bearer {token}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            });

            builder.Services.AddSwaggerGen();



            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();


            //sadece 1 defeliy seed olunur eger yeni klonlamisinizsa async metod edin ve kommentden cixarin bu kodu
            //using (var scope = app.Services.CreateScope())
            //{
            //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            //    foreach (var role in Enum.GetValues<AppRole>())
            //    {
            //        var roleName = role.ToString();
            //        if (!await roleManager.RoleExistsAsync(roleName))
            //        {
            //            await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
            //        }
            //    }
            //}

            app.Run();
        }
    }
}