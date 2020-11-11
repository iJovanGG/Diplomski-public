using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class FacultyStudentView : FacultyUserView
    {
        public string Index { get; set; }
        public ModuleView Module { get; set; }
        public ThesisView AssignedThesis { get; set; }

        public static implicit operator FacultyStudentView(FacultyStudentDTO student)
        {
            if (student == null)
                return null;
            return new FacultyStudentView
            {
                Id = student.Id,
                Email = student.Email,
                FullName = student.FullName,
                Index = student.Index,
                Module = student.Module,
                ProfileImageUrl = student.ProfileImageUrl,
                Role = "Student",
                AssignedThesis = student.AssignedThesis
            };
        }

        public FacultyStudentDTO ToFacultyStudentDTO()
        {
            return new FacultyStudentDTO
            {
                Id = Id,
                Email = Email,
                FullName = FullName,
                Index = Index,
                Module = Module == null ? null : Module.ToModuleDTO(),
                ProfileImageUrl = ProfileImageUrl,
                AssignedThesis = AssignedThesis == null ? null : AssignedThesis.ToThesisDTO()
            };
        }
    }
}
