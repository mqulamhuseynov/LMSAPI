using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Application.Services.Interfaces.Externals
{
    public interface IJwtService
    {
        Task<string> GenerateAccessTokenAsync(AppUser user);
    }
}
