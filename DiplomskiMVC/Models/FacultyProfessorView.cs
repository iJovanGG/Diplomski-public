using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class FacultyProfessorView : FacultyUserView
    {
        public string Office { get; set; }
        public IEnumerable<SubjectView> SubjectList { get; set; }
        public IEnumerable<ThesisView> ThesesList { get; set; }

        public static implicit operator FacultyProfessorView(FacultyProfessorDTO prof)
        {
            if (prof == null)
                return null;
            return new FacultyProfessorView
            {
                Id = prof.Id,
                FullName = prof.FullName,
                Email = prof.Email,
                Office = prof.Office,
                Role = prof.Role,
                ProfileImageUrl = prof.ProfileImageUrl,
                SubjectList = prof.SubjectDTOList == null ? null : prof.SubjectDTOList.Select(e => SubjectView.CastWithoutLists(e)),
                ThesesList = prof.ThesesList == null ? null : prof.ThesesList.Select(t => (ThesisView)t)
            };
        }
        public FacultyProfessorDTO ToFacultyProfessorDTO()
        {
            return new FacultyProfessorDTO
            {
                Id = Id,
                FullName = FullName,
                Email = Email,
                Office = Office
            };
        }
        public static FacultyProfessorView CastWithoutLists(FacultyProfessorDTO prof)
        {
            if (prof == null)
                return null;
            return new FacultyProfessorView
            {
                Id = prof.Id,
                FullName = prof.FullName,
                Email = prof.Email,
                Role = prof.Role,
                ProfileImageUrl = prof.ProfileImageUrl,
                Office = prof.Office
            };
        }
    }
}
