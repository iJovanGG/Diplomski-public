using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entityes
{
    public class Subject
    {
        public int Id { get; set; }
        public Module Module { get; set; }
        public int ModuleId { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<ProfessorSubject> ProfessorSubjectsList { get; set; }
        public IEnumerable<Thesis> Theses { get; set; }
    }
}
