using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.DTOs
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public ModuleDTO Module { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public IEnumerable<FacultyProfessorDTO> ProfessorList { get; set; }
        public IEnumerable<ThesisDTO> Theses { get; set; }

        public static implicit operator SubjectDTO(Subject subject)
        {
            if (subject == null)
                return null;
            return new SubjectDTO
            {
                Id = subject.Id,
                Module = ModuleDTO.CastWithoutLists(subject.Module),
                ModuleId = subject.ModuleId,
                Name = subject.Name,
                ProfessorList = subject.ProfessorSubjectsList == null ? null
                    : subject.ProfessorSubjectsList.Select(e => FacultyProfessorDTO.CastWithoutLists(e.FacultyProfessor)),
                Theses = subject.Theses == null ? null : subject.Theses.Select(e => ThesisDTO.CastWithoutList(e))
            };
        }

        public static SubjectDTO CastWithoutLists(Subject subject)
        {
            if (subject == null)
                return null;
            return new SubjectDTO
            {
                Id = subject.Id,
                Module = ModuleDTO.CastWithoutLists(subject.Module),
                ModuleId = subject.ModuleId,
                Name = subject.Name
            };
        }

        public Subject ToSubject()
        {
            return new Subject
            {
                Id = Id,
                ModuleId = ModuleId,
                Module = Module == null ? null : Module.ToModule(),
                Name = Name
            };
        }
    }
}
