using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entityes
{
    public class Module
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        public IEnumerable<Subject> SubjectsList { get; set; }
    }
}
