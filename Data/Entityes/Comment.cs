using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entityes
{
    public class Comment
    {
        public int Id { get; set; }
        public Thesis Thesis { get; set; }
        public FacultyUser User { get; set; }
        public DateTime Posted { get; set; }
        [MaxLength(300)]
        public string Message { get; set; }
    }
}
