using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class CommentView
    {
        public int Id { get; set; }
        public ThesisView Thesis { get; set; }
        public FacultyUserView User { get; set; }
        public DateTime Posted { get; set; }
        public string Message { get; set; }

        public static implicit operator CommentView(CommentDTO comment)
        {
            if (comment == null)
                return null;
            return new CommentView
            {
                Id = comment.Id,
                Message = comment.Message,
                Posted = comment.Posted,
                Thesis = comment.Thesis,
                User = comment.User
            };
        }

        public CommentDTO ToCommentDTO()
        {
            return new CommentDTO
            {
                Thesis = Thesis.ToThesisDTO(),
                Id = Id,
                Message = Message,
                Posted = Posted,
                User = new FacultyUserDTO { Id = User.Id }
            };
        }
    }
}
