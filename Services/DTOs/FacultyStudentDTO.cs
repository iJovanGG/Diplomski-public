using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class FacultyStudentDTO : FacultyUserDTO
    {
        public string Index { get; set; }
        public ModuleDTO Module { get; set; }
        public ThesisDTO AssignedThesis { get; set; }

        public static implicit operator FacultyStudentDTO(FacultyStudent student)
        {
            if (student == null)
                return null;
            return new FacultyStudentDTO
            {
                Id = student.Id,
                Email = student.Email,
                FullName = student.FullName,
                Index = student.Index,
                Module = ModuleDTO.CastWithoutLists(student.Module),
                ProfileImageUrl = student.ProfileImageUrl,
                AssignedThesis = student.AsignedThesis,
                Role = "Student"
            };
        }

        public FacultyStudent ToFacultyStudent()
        {
            return new FacultyStudent
            {
                Id = Id,
                Email = Email,
                FullName = FullName,
                Index = Index,
                Module = Module == null ? null : Module.ToModule(),
                ProfileImageUrl = ProfileImageUrl,
                AsignedThesis = AssignedThesis == null ? null : AssignedThesis.ToThesis()
            };
        }
    }
}
