using System;
using System.Collections.Generic;
using System.Text;
using Data.Entityes;

namespace Services.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public ThesisDTO Thesis { get; set; }
        public FacultyUserDTO User { get; set; }
        public DateTime Posted { get; set; }
        public string Message { get; set; }

        public static implicit operator CommentDTO(Comment comment)
        {
            if (comment == null)
                return null;
            return new CommentDTO
            {
                Id = comment.Id,
                Message = comment.Message,
                Posted = comment.Posted,
                Thesis = ThesisDTO.CastWithoutList(comment.Thesis),
                User = comment.User
            };
        }

        public Comment ToComment()
        {
            return new Comment
            {
                Thesis = Thesis.ToThesis(),
                Id = Id,
                Message = Message,
                Posted = Posted,
                User = User.ToFacultyUser()
            };
        }
    }
}
