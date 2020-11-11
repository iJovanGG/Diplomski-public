using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class RegistrationDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Index { get; set; }
        public IFormFile ProfileImage { get; set; }
        public string Office { get; set; }
        public int ModuleId { get; set; }
    }
}
