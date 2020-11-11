using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class PaginationView<T, U>
    {
        public IEnumerable<T> ObjectList { get; set; }
        public int TotalCount { get; set; }
        public U SearchQuery { get; set; }
        public string TargetController { get; set; }
        public string TargetAction { get; set; }

        public void FromDto<V>(PaginationDTO<V, U> paginationDto)
        {
            SearchQuery = paginationDto.SearchQuery;
            TotalCount = paginationDto.TotalCount;
            ObjectList = paginationDto.ObjectList == null ? null
                : paginationDto.ObjectList.Select(e => (T)Convert.ChangeType(e, typeof(T)));
        }

        public PaginationView<Object, Object> ToObject()
        {
            return new PaginationView<object, object>
            {
                SearchQuery = (Object)SearchQuery,
                TargetAction = TargetAction,
                TargetController = TargetController,
                TotalCount = TotalCount
            };
        }
    }
}
