using Data.Entityes;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class RequestView
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public ThesisView Thesis { get; set; }
        public int ThesisId { get; set; }
        public FacultyStudentView Student { get; set; }
        public string Response { get; set; }

        public static implicit operator RequestView(RequestDTO request)
        {
            if (request == null)
                return null;
            return new RequestView
            {
                Id = request.Id,
                DateCreated = request.DateCreated,
                Response = request.Response,
                Status = request.Status,
                Student = request.Student,
                Thesis = request.Thesis,
                ThesisId = request.ThesisId
            };
        }

        public RequestDTO ToRequestDTO()
        {
            return new RequestDTO
            {
                ThesisId = ThesisId,
                Thesis = Thesis == null ? null : Thesis.ToThesisDTO(),
                DateCreated = DateCreated,
                Id = Id,
                Response = Response,
                Status = Status,
                Student = Student == null ? null : Student.ToFacultyStudentDTO()
            };
        }
    }
}
