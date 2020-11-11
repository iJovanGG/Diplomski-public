using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.DTOs
{
    public class ThesisDTO
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateTaken { get; set; }
        public DateTime? DatePublished { get; set; }
        public FacultyProfessorDTO Professor { get; set; }
        public SubjectDTO Subject { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Discription { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }

        public static implicit operator ThesisDTO(Thesis thesis)
        {
            if (thesis == null)
                return null;
            return new ThesisDTO
            {
                DateCreated = thesis.DateCreated,
                DateTaken = thesis.DateTaken,
                DateUpdated = thesis.DateUpdated,
                Discription = thesis.Discription,
                Id = thesis.Id,
                Professor = FacultyProfessorDTO.CastWithoutLists( thesis.Professor),
                ShortDescription = thesis.ShortDescription,
                Subject = SubjectDTO.CastWithoutLists(thesis.Subject),
                Title = thesis.Title,
                DatePublished = thesis.DatePublished,
                Comments = thesis.Comments == null? null : thesis.Comments.Select(e=>(CommentDTO)e)
            };
        }

        public static ThesisDTO CastWithoutList(Thesis thesis)
        {
            if (thesis == null)
                return null;
            return new ThesisDTO
            {
                DateCreated = thesis.DateCreated,
                DateTaken = thesis.DateTaken,
                DateUpdated = thesis.DateUpdated,
                Discription = thesis.Discription,
                Id = thesis.Id,
                Professor = FacultyProfessorDTO.CastWithoutLists(thesis.Professor),
                ShortDescription = thesis.ShortDescription,
                Subject = SubjectDTO.CastWithoutLists(thesis.Subject),
                Title = thesis.Title,
                DatePublished = thesis.DatePublished
            };
        }

        public Thesis ToThesis()
        {
            return new Thesis
            {
                DateCreated = DateCreated,
                DateTaken = DateTaken,
                DateUpdated = DateUpdated,
                Discription = Discription,
                Id = Id,
                Professor = Professor == null ? null : Professor.ToFacultyProfessor(),
                ShortDescription = ShortDescription,
                Subject = Subject == null ? null : Subject.ToSubject(),
                Title = Title,
                DatePublished = DatePublished
            };
        }
    }
}
