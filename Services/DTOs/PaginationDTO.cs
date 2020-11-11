using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class PaginationDTO<T, U>
    {
        public IEnumerable<T> ObjectList { get; set; }
        public int TotalCount { get; set; }
        public U SearchQuery { get; set; }
    }
}
