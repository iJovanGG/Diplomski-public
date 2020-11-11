using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Services.DTOs
{
    public class FacultyProfessorDTO : FacultyUserDTO
    {
        public string Office { get; set; }
        public IEnumerable<SubjectDTO> SubjectDTOList { get; set; }
        public IEnumerable<ThesisDTO> ThesesList { get; set; }

        public static implicit operator FacultyProfessorDTO(FacultyProfessor prof)
        {
            if (prof == null)
                return null;
            return new FacultyProfessorDTO
            {
                Id = prof.Id,
                FullName = prof.FullName,
                Email = prof.Email,
                Office = prof.Office,
                ProfileImageUrl = prof.ProfileImageUrl,
                SubjectDTOList = prof.ProfessorSubjectsList == null ? null
                    : prof.ProfessorSubjectsList.Select(e => SubjectDTO.CastWithoutLists(e.Subject)),
                ThesesList = prof.Theses == null ? null : prof.Theses.Select(t => ThesisDTO.CastWithoutList(t))
            };
        }
        public FacultyProfessor ToFacultyProfessor()
        {
            return new FacultyProfessor
            {
                Id = Id,
                FullName = FullName,
                Email = Email,
                Office = Office
            };
        }
        public static FacultyProfessorDTO CastWithoutLists(FacultyProfessor prof)
        {
            if (prof == null)
                return null;
            return new FacultyProfessorDTO
            {
                Id = prof.Id,
                FullName = prof.FullName,
                Email = prof.Email,
                Office = prof.Office,
                ProfileImageUrl = prof.ProfileImageUrl,
                Role = "Professor"
            };
        }
    }
}
