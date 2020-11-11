using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Data.Entityes
{
    public class FacultyUser : IdentityUser
    {
        [MaxLength(100)]
        public string FullName { get; set; }
        public int UserType { get; set; }
        public string ProfileImageUrl { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }

    public enum UserType
    {
        Base,
        Admin,
        Professor,
        Student
    }
}
