using System;
using System.Collections.Generic;
using System.Text;

namespace Services.SearchQuerys
{
    public abstract class SearchQuery
    {
        private int _page = 1;
        private int _perPage = 25;
        public int PerPage
        { 
            get { return _perPage; }
            set { if ((value < 0 && value != -1) || value == 0) { _perPage = 25; } else { _perPage = value; } } 
        }

        public int Page { 
            get { return _page; }
            set { if (value < 1) { _page = 1; } else { _page = value; } }
        }
    }
}
