using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entityes
{
    public class Thesis
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DatePublished { get; set; }
        public DateTime? DateTaken { get; set; }
        public FacultyProfessor Professor { get; set; }
        public Subject Subject { get; set; }
        [MaxLength(128)]
        public string Title { get; set; }
        [MaxLength(300)]
        public string ShortDescription { get; set; }
        public string Discription { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Request> Requests { get; set; }
    }
}
