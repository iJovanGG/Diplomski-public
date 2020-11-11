using Microsoft.AspNetCore.Http;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class RegistrationFieldsProfessor
    {
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Morate uneti ime i prezime")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Morate uneti šifru")]
        [StringLength(60, MinimumLength = 3)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Morate uneti kancelariju")]
        public string Office { get; set; }
        [Required(ErrorMessage = "Morate uneti validnu email adresu")]
        [RegularExpression(@"(.*?(\b@elfak.ni.ac.rs\b))", ErrorMessage = "Morate uneti validnu @elfak.ni.ac.rs adresu")]
        public string Email { get; set; }
        public IFormFile UserImage { get; set; }

        public RegistrationDTO ToRegistrationDTO()
        {
            return new RegistrationDTO
            {
                Email = Email,
                FullName = FullName,
                Office = Office,
                Password = Password,
                ProfileImage = UserImage
            };
        }
    }
}
