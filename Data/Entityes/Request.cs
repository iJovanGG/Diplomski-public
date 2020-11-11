using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entityes
{
    public class Request
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public Thesis Thesis { get; set; }
        public int ThesisId { get; set; }
        public FacultyStudent Student { get; set; }
        public string StudentId { get; set; }
        public string Response { get; set; }
    }

    public enum RequestStatus
    {
        Pending,
        Accepted,
        Denied,
        TakenBySomeoneElse,
        Canceled
    }
}
