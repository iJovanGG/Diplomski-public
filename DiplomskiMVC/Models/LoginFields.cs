using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class LoginFields
    {
        [Required(ErrorMessage = "Morate uneti šifru")]
        [StringLength(60, MinimumLength = 3)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Morate uneti validnu email adresu")]
        [RegularExpression(@"(.*?((\b@elfak.ni.ac.rs\b)|(\b@elfak.rs\b)|(\b@admin.com\b)))", ErrorMessage = "Morate uneti validnu email adresu")]
        public string Email { get; set; }
    }
}
