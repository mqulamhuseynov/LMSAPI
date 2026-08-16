using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLMSAPI.Application.DTOs.Requests.Auth
{
    public class LoginRequestDTO
    {
        public string PersonalCode { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
