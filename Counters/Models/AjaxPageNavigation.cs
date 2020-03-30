using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Counters.Models
{
    public class AjaxPageNavigation
    {
        public int Count { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public List<Counter> Data { get; set; }

        public AjaxPageNavigation(int count, int recordInPage, int pageNumber)
        {
            Count = count;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)recordInPage);
        }
    }
}
