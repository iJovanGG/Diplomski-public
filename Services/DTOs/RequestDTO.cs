using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public ThesisDTO Thesis { get; set; }
        public int ThesisId { get; set; }
        public FacultyStudentDTO Student { get; set; }
        public string Response { get; set; }

        public static implicit operator RequestDTO(Request request)
        {
            if (request == null)
                return null;
            return new RequestDTO
            {
                Id = request.Id,
                DateCreated = request.DateCreated,
                Response = request.Response,
                Status = request.Status,
                Student = request.Student,
                Thesis = ThesisDTO.CastWithoutList(request.Thesis),
                ThesisId = request.ThesisId
            };
        }

        public Request ToRequest()
        {
            return new Request
            {
                ThesisId = ThesisId,
                Thesis = Thesis == null ? null : Thesis.ToThesis(),
                DateCreated = DateCreated,
                Id = Id,
                Response = Response,
                Status = Status,
                Student = Student == null ? null : Student.ToFacultyStudent()
            };
        }
    }
}
