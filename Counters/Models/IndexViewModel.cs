using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Counters.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Counter> Counters { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
