using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class SubjectView
    {
        public int Id { get; set; }
        public ModuleView Module { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public IEnumerable<FacultyProfessorView> ProfessorList { get; set; }
        public IEnumerable<ThesisView> ThesisViews { get; set; }

        public static implicit operator SubjectView(SubjectDTO subjectDTO)
        {
            if (subjectDTO == null)
                return null;
            return new SubjectView
            {
                Id = subjectDTO.Id,
                Module = ModuleView.CastWithoutList(subjectDTO.Module),
                ModuleId = subjectDTO.ModuleId,
                Name = subjectDTO.Name,
                ProfessorList = subjectDTO.ProfessorList == null ? null
                    : subjectDTO.ProfessorList.Select(e => FacultyProfessorView.CastWithoutLists(e)),
                ThesisViews = subjectDTO.Theses == null ? null : subjectDTO.Theses.Select(e => (ThesisView)e)
            };
        }

        internal static SubjectView CastWithoutLists(SubjectDTO subject)
        {
            return new SubjectView
            {
                Id = subject.Id,
                ModuleId = subject.ModuleId,
                Module = ModuleView.CastWithoutList(subject.Module),
                Name = subject.Name
            };
        }

        public SubjectDTO ToSubjectDTO()
        {
            return new SubjectDTO
            {
                Id = Id,
                ModuleId = ModuleId,
                Name = Name
            };
        }
    }
}
