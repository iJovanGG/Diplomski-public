using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class FacultyUserView
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }

        public static implicit operator FacultyUserView(FacultyUserDTO user)
        {
            if (user == null)
                return null;
            return new FacultyUserView
            {
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id,
                ProfileImageUrl = user.ProfileImageUrl,
                Role = user.Role
            };
        }
    }
}
