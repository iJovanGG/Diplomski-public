using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class FacultyUserDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }

        public static implicit operator FacultyUserDTO(FacultyUser user)
        {
            if (user == null)
                return null;
            else
            {
                return new FacultyUserDTO
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Role = ((UserType)user.UserType).ToString("g"),
                    Email = user.Email,
                    ProfileImageUrl = user.ProfileImageUrl
                };
            }
        }

        public FacultyUser ToFacultyUser()
        {
            return new FacultyUser
            {
                Id = Id,
                FullName = FullName,
                Email = Email,
                ProfileImageUrl = ProfileImageUrl,
                UserType = Role == null ? 0 : (int)(UserType)Enum.Parse(typeof(UserType), Role)
            };
        }
    }
}
