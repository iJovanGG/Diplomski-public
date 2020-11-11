using System;
using System.Collections.Generic;
using System.Text;

namespace Services.SearchQuerys
{
    public class RequestSearchQuery : SearchQuery
    {
        public int ThesisId { get; set; }
        public RequestsOrderBy OrderBy { get; set; } = RequestsOrderBy.DatePosted;
        public bool OrderAscending { get; set; } = true;
        public bool HideCompleted { get; set; } = true;
    }

    public enum RequestsOrderBy
    {
        ThesisId,
        DatePosted,
        Status
    }
}
