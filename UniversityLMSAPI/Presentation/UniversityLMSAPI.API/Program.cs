
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UniversityLMSAPI.Application.Services.Implementations;
using UniversityLMSAPI.Application.Services.Interfaces;
using UniversityLMSAPI.Domain.Entities;
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

            builder.Services.AddDbContext<AppDbContext>(options =>  options.UseNpgsql(connectionString));

            builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
            {
                //identity options configleri
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
            //Dependecy injections
            builder.Services.AddJwtAuthentication(builder.Configuration);
            builder.Services.AddScoped<IAuthService, AuthService>();



            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
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

            app.Run();
        }
    }
}
