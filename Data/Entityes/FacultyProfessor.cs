using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entityes
{
    public class FacultyProfessor : FacultyUser
    {
        public string Office { get; set; }
        public IEnumerable<ProfessorSubject> ProfessorSubjectsList { get; set; }
        public IEnumerable<Thesis> Theses { get; set; }
    }
}
