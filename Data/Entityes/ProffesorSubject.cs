using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entityes
{
    public class ProfessorSubject
    {
        public FacultyProfessor FacultyProfessor { get; set; }
        public string ProfessorId { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
    }
}
