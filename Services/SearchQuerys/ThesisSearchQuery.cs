using System;
using System.Collections.Generic;
using System.Text;

namespace Services.SearchQuerys
{
    public class ThesisSearchQuery : SearchQuery
    {
        public List<string> ProfessorId { get; set; } = new List<string>();
        public List<int> SubjectId { get; set; } = new List<int>();
        public string Title { get; set; }
        public bool HideTaken { get; set; } = true;
        public int ModuleId { get; set; } = 1;
    }
}
