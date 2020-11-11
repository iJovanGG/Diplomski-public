using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entityes
{
    public class FacultyStudent : FacultyUser
    {
        public string Index { get; set; }
        public Module Module { get; set; }
        public Thesis AsignedThesis { get; set; }
        public IEnumerable<Request> Requests { get; set; }
    }
}
