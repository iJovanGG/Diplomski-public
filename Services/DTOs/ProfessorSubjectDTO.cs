using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class ProfessorSubjectDTO
    {
        public FacultyProfessorDTO FacultyProfessorDTO { get; set; }
        public string ProfessorId { get; set; }
        public SubjectDTO SubjectDTO { get; set; }
        public int SubjectId { get; set; }


        public static implicit operator ProfessorSubjectDTO(ProfessorSubject professorSubject)
        {
            if (professorSubject == null)
                return null;
            return new ProfessorSubjectDTO
            {
                SubjectId = professorSubject.SubjectId,
                SubjectDTO = SubjectDTO.CastWithoutLists(professorSubject.Subject),
                ProfessorId = professorSubject.ProfessorId,
                FacultyProfessorDTO = FacultyProfessorDTO.CastWithoutLists(professorSubject.FacultyProfessor)
            };
        }
    }
}
