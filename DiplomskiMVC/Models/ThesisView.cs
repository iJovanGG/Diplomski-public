using Services.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class ThesisView
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateTaken { get; set; }
        public DateTime? DatePublished { get; set; }
        public FacultyProfessorView Professor { get; set; }
        public FacultyStudentView? TakenByStudent { get; set; }
        [Required(ErrorMessage = "Morate odabrati predmet")]
        public SubjectView Subject { get; set; }
        [MaxLength(128)]
        [Required(ErrorMessage = "Morate uneti naziv teme")]
        public string Title { get; set; }
        [MaxLength(300)]
        [Required(ErrorMessage = "Morate uneti kratak opis")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Morate uneti opis")]
        public string Discription { get; set; }
        public IEnumerable<CommentView> Comments { get; set; }

        public static implicit operator ThesisView(ThesisDTO thesis)
        {
            if (thesis == null)
                return null;
            return new ThesisView
            {
                DateCreated = thesis.DateCreated,
                DateTaken = thesis.DateTaken,
                DateUpdated = thesis.DateUpdated,
                Discription = thesis.Discription,
                Id = thesis.Id,
                Professor = thesis.Professor,
                ShortDescription = thesis.ShortDescription,
                Subject = thesis.Subject,
                Title = thesis.Title,
                DatePublished = thesis.DatePublished,
                Comments = thesis.Comments == null ? null : thesis.Comments.Select(e=>(CommentView)e)
            };
        }

        public ThesisDTO ToThesisDTO()
        {
            return new ThesisDTO
            {
                DateCreated = DateCreated,
                DateTaken = DateTaken,
                DateUpdated = DateUpdated,
                Discription = Discription,
                Id = Id,
                Professor = Professor == null ? null : Professor.ToFacultyProfessorDTO(),
                ShortDescription = ShortDescription,
                Subject = Subject == null ? null : Subject.ToSubjectDTO(),
                Title = Title,
                DatePublished = DatePublished,
                Comments = Comments == null ? null : Comments.Select(e => e.ToCommentDTO())
            };
        }


    }
}
